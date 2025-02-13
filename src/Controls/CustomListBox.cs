/*
 * MIT License
 * 
 * This software is provided under the MIT License, a permissive license that allows for the use, copying, modification, 
 * merging, publishing, distribution, sublicensing, and sale of copies of the software, as long as the original 
 * permission and disclaimer are included in all copies or substantial portions of the software.
 * 
 * For more details about the MIT License and its terms, please refer to:
 * https://github.com/rodriaum/IP-Address-Lookup?tab=MIT-1-ov-file#readme
 * 
 * This project is an IP address lookup system developed in C#.
 * 
 * Copyright (c) 2024 Rodrigo Ferreira
 */

namespace IP_Address_Lookup.src.Controls
{
    public class CustomListBox : ListBox
    {
        private static Color _backColor = Color.FromArgb(15, 19, 32);

        public CustomListBox()
        {
            this.BackColor = _backColor;
            this.ForeColor = Color.White;
            this.SelectionMode = SelectionMode.None;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), e.Bounds);
            }

            // Remover o foco do item
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
            }
        }
    }
}
