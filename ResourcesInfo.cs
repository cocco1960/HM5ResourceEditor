using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM5ResourceEditor
{
    public partial class ResourcesInfo : Form
    {
        private ZLocalResourceFileMediator localResourceFileMediator = new ZLocalResourceFileMediator();
        private List<Resource> resources = new List<Resource>();

        public string GamePath
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public ResourcesInfo()
        {
            InitializeComponent();
        }

        private void ResourcesInfo_Load(object sender, EventArgs e)
        {
            ParseHeaderlib();

            List<string> resourceIDs = resources.Select(r => r.ResourceID).ToList();

            lbResourceIDs.Items.AddRange(resourceIDs.ToArray());
        }

        private bool ParseHeaderlib()
        {
            try
            {
                using (FileStream headerFileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader headerBinaryReader = new BinaryReader(headerFileStream))
                    {
                        headerBinaryReader.ReadInt32();
                        headerFileStream.Seek(headerBinaryReader.ReadInt32() + 64, SeekOrigin.Current);

                        int numberOfResourceIDs = headerBinaryReader.ReadInt32();
                        long[] resourceIDOffsets = new long[numberOfResourceIDs];
                        long[] resourceOffsetsInHeaderlib = new long[numberOfResourceIDs];

                        headerBinaryReader.ReadInt32();

                        for (int j = 0; j < numberOfResourceIDs; j++)
                        {
                            resourceIDOffsets[j] = headerFileStream.Position + headerBinaryReader.ReadInt32();

                            headerFileStream.Seek(36, SeekOrigin.Current);

                            resourceOffsetsInHeaderlib[j] = headerFileStream.Position + headerBinaryReader.ReadInt32();

                            headerFileStream.Seek(36, SeekOrigin.Current);
                        }

                        for (int j = 0; j < numberOfResourceIDs; j++)
                        {
                            headerFileStream.Seek(resourceIDOffsets[j] - 4, SeekOrigin.Begin);

                            int resourceIDLength = headerBinaryReader.ReadInt32();
                            string resourceID = new string(headerBinaryReader.ReadChars(resourceIDLength - 1));

                            headerFileStream.Seek(resourceOffsetsInHeaderlib[j] - 4, SeekOrigin.Begin);

                            int numberOfResourceComponents = headerBinaryReader.ReadInt32();
                            long[] resouceOffsetsInResourceLib = new long[numberOfResourceComponents];

                            for (int k = 0; k < numberOfResourceComponents; k++)
                            {
                                resouceOffsetsInResourceLib[k] = headerFileStream.Position + headerBinaryReader.ReadInt32();

                                headerBinaryReader.ReadInt64();
                            }

                            Resource resource = new Resource();

                            if (!ParseResourcelib(ref resource, headerFileStream, headerBinaryReader, resouceOffsetsInResourceLib, resourceID))
                            {
                                return false;
                            }

                            resources.Add(resource);
                        }
                    }
                }

                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private bool ParseResourcelib(ref Resource resource, FileStream headerFileStream, BinaryReader headerBinaryReader, long[] resouceOffsetsInResourceLib, string resourceID)
        {
            try
            {
                ZResourceID resourceID2 = new ZResourceID(resourceID);
                string filePath = localResourceFileMediator.GetResourceFileName(resourceID2);
                int numberOfResourceComponents = resouceOffsetsInResourceLib.Length;

                resource.ResourceID = resourceID;
                resource.FilePath = filePath;

                filePath = GamePath + filePath.Substring(2);

                using (FileStream resourceFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader resourceBinaryReader = new BinaryReader(resourceFileStream))
                    {
                        SResourceHeaderHeader resourceHeaderHeader = new SResourceHeaderHeader
                        {
                            type = Reverse(resourceBinaryReader.ReadChars(4)),
                            referencesChunkSize = resourceBinaryReader.ReadUInt32(),
                            statesChunkSize = resourceBinaryReader.ReadUInt32(),
                            dataSize = resourceBinaryReader.ReadUInt32(),
                            systemMemoryRequirement = resourceBinaryReader.ReadUInt32(),
                            videoMemoryRequirement = resourceBinaryReader.ReadUInt32()
                        };

                        resource.ResourceHeaderHeader = resourceHeaderHeader;

                        Dictionary<int, Dictionary<string, long>> extensions = new Dictionary<int, Dictionary<string, long>>();

                        for (int k = 0; k < numberOfResourceComponents; k++)
                        {
                            headerFileStream.Seek(resouceOffsetsInResourceLib[k], SeekOrigin.Begin);

                            string resourceExtension = Reverse(headerBinaryReader.ReadChars(4));

                            extensions.Add(k, new Dictionary<string, long>());

                            extensions[k].Add(resourceExtension, resouceOffsetsInResourceLib[k]);
                        }

                        resource.Extensions = extensions;
                    }
                }

                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private string Reverse(char[] charArray)
        {
            Array.Reverse(charArray);

            return new string(charArray);
        }

        private void LbResourceIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resource resource = resources[lbResourceIDs.SelectedIndex];

            lblType.Text = "Type: " + resource.ResourceHeaderHeader.type;
            lblReferencesChunkSize.Text = "References Chunk Size: 0x" + resource.ResourceHeaderHeader.referencesChunkSize.ToString("X");
            lblStatesChunkSize.Text = "States Chunk Size: 0x" + resource.ResourceHeaderHeader.statesChunkSize.ToString("X");
            lblDataSize.Text = "Data Size: 0x" + resource.ResourceHeaderHeader.dataSize.ToString("X");
            lblSystemMemoryRequirement.Text = "System Memory Requirement: 0x" + resource.ResourceHeaderHeader.systemMemoryRequirement.ToString("X");
            lblVideoMemoryRequirement.Text = "Video Memory Requirement: 0x" + resource.ResourceHeaderHeader.videoMemoryRequirement.ToString("X");
            lblFilePath.Text = "File path: " + resource.FilePath;

            int count = resource.Extensions.Count;
            List<ListViewItem> listViewItems = new List<ListViewItem>();

            for (int i = 0; i < count; i++)
            {
                ListViewItem listViewItem = new ListViewItem(resource.Extensions.ElementAt(i).Value.ElementAt(0).Key);

                listViewItem.SubItems.Add("0x" + resource.Extensions.ElementAt(i).Value.ElementAt(0).Value.ToString("X"));

                listViewItems.Add(listViewItem);
            }

            lvExtensions.Items.Clear();
            lvExtensions.BeginUpdate();
            lvExtensions.Items.AddRange(listViewItems.ToArray());
            lvExtensions.EndUpdate();
        }
    }
}
