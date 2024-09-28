namespace AdminAPP.Libraries
{
    public static class StringHelper
    {

        /// <summary>
        /// 对文本进行指定长度截取并添加省略号
        /// </summary>
        /// <param name="NeiRong"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string? SubstringText(this string text, int length)
        {

            if (text != null && text.Length > length)
            {
                text = text[..length];
                text += "...";
                return text;
            }
            else
            {
                return text;
            }

        }
    }
}
