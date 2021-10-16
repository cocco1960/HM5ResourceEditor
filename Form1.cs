using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace HM5ResourceEditor
{
	public partial class Form1 : Form
	{
		private readonly Configuration configuration = new Configuration();
		private string selectedNode = "";
		private ZLocalResourceFileMediator localResourceFileMediator = new ZLocalResourceFileMediator();

		public Form1()
		{
			InitializeComponent();

			treeView1.ContextMenuStrip = contextMenuStrip1;
			lvHeaderlibs.ContextMenuStrip = contextMenuStrip2;

			lblHeaderInfo.Hide();
			lblType.Hide();
			lblReferencesChunkSize.Hide();
			lblStatesChunkSize.Hide();
			lblDataSize.Hide();
			lblSystemMemoryRequirement.Hide();
			lblVideoMemoryRequirement.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
		{
			if (!File.Exists("HM5ResourceEditor.ini"))
			{
				File.Create("HM5ResourceEditor.ini").Dispose();
			}

			string gamePath = configuration.GetGamePath();

			if (gamePath != null)
			{
				txtGamePath.Text = gamePath;
				ListDirectories();
			}
			else
			{
				txtGamePath.Text = "Select game path";

				if (!configuration.CheckIfGamePathEntryAdded())
				{
					configuration.WriteGamePath("");
				}
			}
		}

		private void AddHeaderLibs(string folderName)
		{
			string path = Path.Combine(txtGamePath.Text, "runtime", folderName);
			string[] files = Directory.GetFiles(path, "*.pc_headerlib*", SearchOption.AllDirectories);
			int count = files.Length;

			ListViewItem[] listViewItems = new ListViewItem[files.Length];

			for (int i = 0; i < count; i++)
			{
				string fileName = new FileInfo(files[i]).Name;
				ListViewItem listViewItem = new ListViewItem(fileName);
				listViewItems[i] = listViewItem;
			}

			lvHeaderlibs.Items.Clear();

			lvHeaderlibs.BeginUpdate();
			lvHeaderlibs.Items.AddRange(listViewItems);
			lvHeaderlibs.EndUpdate();
		}

		private void ListDirectories()
		{
			treeView1.Nodes.Clear();

			string folderPath = Path.Combine(txtGamePath.Text, "runtime");
			DirectoryInfo rootDirectoryInfo = new DirectoryInfo(folderPath);

			foreach (var directory in rootDirectoryInfo.GetDirectories())
			{
				treeView1.Nodes.Add(CreateDirectoryNode(directory));
			}
		}

		private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
		{
			TreeNode directoryNode = new TreeNode(directoryInfo.Name);

			foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
			{
				directoryNode.Nodes.Add(CreateDirectoryNode(directory));
			}

			return directoryNode;
		}

		private void ShowOpenFileDialog(out string folderPath)
		{
			folderPath = null;

			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				ValidateNames = false,
				CheckFileExists = false,
				CheckPathExists = true,
				FileName = "Folder Selection."
			};

			DialogResult dialogResult = openFileDialog.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				folderPath = Path.GetDirectoryName(openFileDialog.FileName);
			}
		}

		private void BtnSelectGamePath_Click(object sender, EventArgs e)
		{
			ShowOpenFileDialog(out string folderPath);

			txtGamePath.Text = folderPath;

			ListDirectories();

			configuration.WriteGamePath(txtGamePath.Text);
		}

        private void BtnSelectExportPath_Click(object sender, EventArgs e)
        {
			ShowOpenFileDialog(out string folderPath);

			txtExportPath.Text = folderPath;
		}

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			selectedNode = e.Node.FullPath;

			AddHeaderLibs(selectedNode);
		}

		private void LvResourceLibs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!lblHeaderInfo.Visible)
			{
				ShowControls();
			}

			SResourceHeaderHeader resourceHeaderHeader = GetHeaderInfo();

			lblType.Text = "Type: " + resourceHeaderHeader.type;
			lblReferencesChunkSize.Text = "References Chunk Size: 0x" + resourceHeaderHeader.referencesChunkSize;
			lblStatesChunkSize.Text = "States Chunk Size: 0x" + resourceHeaderHeader.statesChunkSize;
			lblDataSize.Text = "Data Size: 0x" + resourceHeaderHeader.dataSize;
			lblSystemMemoryRequirement.Text = "System Memory Requirement: 0x" + resourceHeaderHeader.systemMemoryRequirement;
			lblVideoMemoryRequirement.Text = "Video Memory Requirement: 0x" + resourceHeaderHeader.videoMemoryRequirement;
		}

		private void ShowControls()
		{
			lblHeaderInfo.Show();
			lblType.Show();
			lblReferencesChunkSize.Show();
			lblStatesChunkSize.Show();
			lblDataSize.Show();
			lblSystemMemoryRequirement.Show();
			lblVideoMemoryRequirement.Show();
		}

		private SResourceHeaderHeader GetHeaderInfo()
		{
			SResourceHeaderHeader resourceHeaderHeader = new SResourceHeaderHeader();
			string path = Path.Combine(txtGamePath.Text, "runtime", selectedNode, lvHeaderlibs.Items[0].Text);

			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader(fileStream))
				{
					resourceHeaderHeader.type = Reverse(binaryReader.ReadChars(4));
					resourceHeaderHeader.referencesChunkSize = binaryReader.ReadUInt32();
					resourceHeaderHeader.statesChunkSize = binaryReader.ReadUInt32();
					resourceHeaderHeader.dataSize = binaryReader.ReadUInt32();
					resourceHeaderHeader.systemMemoryRequirement = binaryReader.ReadUInt32();
					resourceHeaderHeader.videoMemoryRequirement = binaryReader.ReadUInt32();
				}
			}

			return resourceHeaderHeader;
		}

		private bool ExportFile(string headerlibPath)
		{
			return ParseHeaderlib(headerlibPath);
		}

		private bool ParseHeaderlib(string headerlibPath)
		{
			try
			{
                using (FileStream headerFileStream = new FileStream(headerlibPath, FileMode.Open, FileAccess.Read))
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

							if (!ParseResourcelib(headerFileStream, headerBinaryReader, resouceOffsetsInResourceLib, resourceID,
								headerlibPath))
							{
								return false;
							}
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

		private bool ParseResourcelib(FileStream headerFileStream, BinaryReader headerBinaryReader, long[] resouceOffsetsInResourceLib, string resourceID, string headerlibPath)
        {
			try
			{
                ZResourceID resourceID2 = new ZResourceID(resourceID);
                string filePath = localResourceFileMediator.GetResourceFileName(resourceID2);
				string resourceName = "";

				if (resourceID.Contains("?"))
                {
                    int startIndex = resourceID.IndexOf('?') + 2;
                    int count = resourceID.IndexOf('.', resourceID.IndexOf('?')) - resourceID.IndexOf('?') - 2;

					resourceName = resourceID.Substring(startIndex, count);
                }

				if (headerlibPath.Contains("DLC"))
				{
					filePath = headerlibPath.Substring(0, headerlibPath.LastIndexOf(@"\runtime")) + filePath.Substring(2);
				}
				else
				{
					filePath = txtGamePath.Text + filePath.Substring(2);
				}

                if (!File.Exists(filePath))
                {
					return true;
                }

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
				string exportPath = Path.Combine(txtExportPath.Text, fileNameWithoutExtension);

				Directory.CreateDirectory(exportPath);

				int resourcePosition = 24;
				int numberOfResourceComponents = resouceOffsetsInResourceLib.Length;

                using (FileStream resourceFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
					using (BinaryReader resourceBinaryReader = new BinaryReader(resourceFileStream))
                    {
                        for (int k = 0; k < numberOfResourceComponents; k++)
                        {
                            headerFileStream.Seek(resouceOffsetsInResourceLib[k], SeekOrigin.Begin);

                            string resourceExtension = Reverse(headerBinaryReader.ReadChars(4));

                            headerBinaryReader.ReadInt64();

                            int resourceSize = headerBinaryReader.ReadInt32();
                            byte[] currentResData = new byte[resourceSize];

							resourceFileStream.Seek(resourcePosition, SeekOrigin.Begin);
							resourceFileStream.Read(currentResData, 0, resourceSize);

							string newFileName;
                            string newFilePath;

                            if (resourceID.Contains("?"))
                            {
								newFileName = resourceName + "_" + k;
                            }
                            else
                            {
								newFileName = k.ToString();
							}

                            newFilePath = Path.Combine(exportPath, newFileName + "." + resourceExtension);
                            resourcePosition += resourceSize;

							File.WriteAllBytes(newFilePath, currentResData);
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

		private string Reverse(char[] charArray)
		{
			Array.Reverse(charArray);

			return new string(charArray);
		}

        private void TsmiExportFile_Click(object sender, EventArgs e)
        {
            int count = lvHeaderlibs.SelectedItems.Count;
            List<string> fileNames = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string fileName = lvHeaderlibs.SelectedItems[i].Text;
                string filePath = Path.Combine(txtGamePath.Text, "runtime", selectedNode, fileName);

                if (!ExportFile(filePath))
                {
                    fileNames.Add(fileName);
                }
            }

            string message = "Done.";

            if (fileNames.Count > 0)
            {
                message += " Files that weren't exported:\n";
                message += string.Join("\n", fileNames);
            }

            MessageBox.Show(message, "HM5 Resource Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TsmiExportAllFilesInSelectedFolder_Click(object sender, EventArgs e)
		{
			int count = lvHeaderlibs.Items.Count;
			List<string> fileNames = new List<string>();

			for (int i = 0; i < count; i++)
			{
				string fileName = lvHeaderlibs.Items[i].Text;
				string filePath = Path.Combine(txtGamePath.Text, "runtime", selectedNode, fileName);

                if (!ExportFile(filePath))
                {
                    fileNames.Add(fileName);
                }
            }

            string message = "Done.";

            if (fileNames.Count > 0)
            {
                message += " Files that weren't exported:\n";
                message += string.Join("\n", fileNames);
            }

            MessageBox.Show(message, "HM5 Resource Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TsmiExportFilesFromFromAllFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
			string folderPath = Path.Combine(txtGamePath.Text, "runtime");
			string[] files = Directory.GetFiles(folderPath, "*.pc_headerlib*", SearchOption.AllDirectories);
			int count = files.Length;
            List<string> fileNames = new List<string>();

            for (int i = 0; i < count; i++)
            {
                if (!ExportFile(files[i]))
                {
					fileNames.Add(new FileInfo(files[i]).Name);
                }
            }

            string message = "Done.";

            if (fileNames.Count > 0)
            {
                message += " Files that weren't exported:\n";
                message += string.Join("\n", fileNames);
            }

            MessageBox.Show(message, "HM5 Resource Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			selectedNode = e.Node.FullPath;
			treeView1.SelectedNode = e.Node;

			lblWorkingDirectory.Text = "Working Directory: " + e.Node.FullPath;
		}

		private void TsmiExportOutfitNames_Click(object sender, EventArgs e)
		{
			GetResourceIDs(@"templates\characters\hitman\outfits", "Character ResourceIDs.txt", "Character Names.txt");
		}

		private void TsmiExportItemNames_Click(object sender, EventArgs e)
		{
			GetResourceIDs(@"templates\itemtemplates", "Item ResourceIDs.txt", "Item Names.txt");
		}

		private void TsmiExportWeaponNames_Click(object sender, EventArgs e)
		{
			GetResourceIDs(@"templates\weapontemplates", "Weapon ResourceIDs.txt", "Weapon Names.txt");
		}

		private void GetResourceIDs(string path, string fileName, string fileName2)
		{
			try
			{
				string folderPath = Path.Combine(txtGamePath.Text, path);
				string[] files = Directory.GetFiles(folderPath, "*.pc_headerlib*", SearchOption.AllDirectories);
				List<string> resourceIDs = new List<string>();
				List<string> names = new List<string>();
				int filesCount = files.Length;

				for (int i = 0; i < filesCount; i++)
				{
					resourceIDs.AddRange(FindResourceIDs("[[assembly", files[i]));
				}

				resourceIDs = resourceIDs.Distinct().ToList();
				int resourceIDsCount = resourceIDs.Count;

				for (int i = 0; i < resourceIDsCount; i++)
				{
					if (resourceIDs[i].Contains("?"))
					{
						int startIndex = resourceIDs[i].IndexOf('?') + 2;
						int count = resourceIDs[i].IndexOf('.', resourceIDs[i].IndexOf('?')) - resourceIDs[i].IndexOf('?') - 2;

						string resourceName = resourceIDs[i].Substring(startIndex, count);

						names.Add(resourceName);
					}
				}

				names = names.Distinct().ToList();

				File.WriteAllLines(fileName, resourceIDs);
				File.WriteAllLines(fileName2, names);
			}
			catch (IOException ex)
			{
				MessageBox.Show(ex.Message);
			}

			MessageBox.Show("Done.", "HM5ResourceEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private List<string> FindResourceIDs(string stringToFind, string path)
		{
			List<string> names = new List<string>();

			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader(fileStream))
				{
					byte[] ByteBuffer = File.ReadAllBytes(path);
					byte[] StringBytes = Encoding.UTF8.GetBytes(stringToFind);

					for (int i = 0; i <= (ByteBuffer.Length - StringBytes.Length); i++)
					{
						if (ByteBuffer[i] == StringBytes[0])
						{
							int j;
							for (j = 1; j < StringBytes.Length && ByteBuffer[i + j] == StringBytes[j]; j++) ;

							if (j == StringBytes.Length)
							{
								fileStream.Seek(i, SeekOrigin.Begin);

								byte letter;
								string fileName = "";

								while ((letter = binaryReader.ReadByte()) != 0)
								{
									fileName += Encoding.Default.GetString(new byte[] { letter });
								}

								names.Add(fileName);
							}
						}
					}
				}
			}

			return names;
		}

        private void BtnDisplayResourcesInfo_Click(object sender, EventArgs e)
        {
			string filePath = Path.Combine(txtGamePath.Text, "runtime", selectedNode, lvHeaderlibs.SelectedItems[0].Text);

			ResourcesInfo resourcesInfo = new ResourcesInfo
			{
				GamePath = txtGamePath.Text,
				FilePath = filePath
			};

            resourcesInfo.ShowDialog();
        }
    }
}
