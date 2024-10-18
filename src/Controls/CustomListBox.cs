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
