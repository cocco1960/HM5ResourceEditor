using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HM5ResourceEditor
{
    public class ZResourceID
    {
        public string Uri
        {
            get;
            set;
        }

        public ZResourceID()
        {
            Uri = "";
        }

        public ZResourceID(string uri)
        {
            Uri = uri;
        }

        public int FindMatchingParentheses(string str, int startIndex, char open, char close)
        {
            int result;
            int count;
            int index;
            int length;

            result = str.IndexOf(open, startIndex);

            if (result != -1)
            {
                count = 1;
                index = result + 1;
                length = str.Length;

                if (index >= length)
                {
                    result = -1;
                }
                else
                {
                    while (true)
                    {
                        char c = str[index];

                        if (c == open)
                        {
                            count++;
                        }
                        else if (c == close)
                        {
                            count--;
                        }

                        if (count == 0)
                        {
                            break;
                        }

                        if (++index >= length)
                        {
                            result = -1;

                            break;
                        }
                    }

                    result = index;
                }
            }

            return result;
        }

        public int GetDerivedEndIndex()
        {
            int result;

            if (Uri.Length <= 0 || Uri[0] != '[')
            {
                return 0;
            }

            result = FindMatchingParentheses(Uri, 0, '[', ']') + 1;

            if (Uri[result] == '(')
            {
                result = FindMatchingParentheses(Uri, result, '(', ')') + 1;
            }

            return result;
        }

        public string GetExtension()
        {
            string result;
            int derivedEndIndex = GetDerivedEndIndex();
            int index = Uri.IndexOf('?', derivedEndIndex);

            if (index == -1)
            {
                index = derivedEndIndex;
            }

            int lastIndex = Uri.LastIndexOf('.', index);

            if (lastIndex < 0)
            {
                result = "";
            }
            else
            {
                result = Uri.Substring(lastIndex + 1);
            }

            return result;
        }

        public string GetPlatformFromExtension()
        {
            string result;
            string extension;
            int derivedEndIndex = GetDerivedEndIndex();
            int index = Uri.IndexOf('?', derivedEndIndex);

            if (index == -1)
            {
                index = derivedEndIndex;
            }

            int lastIndex = Uri.LastIndexOf('.', index);

            if (lastIndex < 0)
            {
                extension = "";
            }
            else
            {
                extension = Uri.Substring(lastIndex + 1);
            }

            index = extension.IndexOf('_');

            if (index == -1)
            {
                result = "";
            }
            else
            {
                result = extension.Substring(0, index);
            }

            return result;
        }

        public bool IsDerived()
        {
            bool result;

            if (Uri.Length <= 0)
            {
                result = false;
            }
            else
            {
                result = Uri[0] == '[';
            }

            return result;
        }

        public ZResourceID GetSourceResourceID()
        {
            ZResourceID result = new ZResourceID
            {
                Uri = Uri.Substring(1, FindMatchingParentheses(Uri, 0, '[', ']') - 1)
            };

            return result;
        }

        public ZResourceID GetRoot()
        {
            ZResourceID result = new ZResourceID();

            int derivedEndIndex = GetDerivedEndIndex();
            int index = Uri.IndexOf('?', derivedEndIndex);

            if (index == -1)
            {
                result.Uri = Uri;
            }
            else
            {
                result.Uri = Uri.Substring(0, index);
            }

            return result;
        }

        public static ZResourceID GetInnermostSourceRootID(ZResourceID id)
        {
            ZResourceID result;

            if (id.IsDerived())
            {
                ZResourceID sourceResourceID = id.GetSourceResourceID();
                ZResourceID root = sourceResourceID.GetRoot();

                result = GetInnermostSourceRootID(root);
            }
            else
            {
                result = id.GetRoot();
            }

            return result;
        }

        public ZResourceID ReplaceExtension(string extension)
        {
            ZResourceID result = new ZResourceID();

            int derivedEndIndex = GetDerivedEndIndex();
            int lastIndex = Uri.LastIndexOf('.', derivedEndIndex);

            if (lastIndex < 0)
            {
                Uri += ".";
                Uri += extension;

                result.Uri = Uri;
            }
            else
            {
                result.Uri = Uri.Substring(0, lastIndex + 1);
                result.Uri += extension;
            }

            return result;
        }
    }
}
