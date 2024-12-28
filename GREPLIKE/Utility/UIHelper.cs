namespace GREPLIKE.Utility
{
    internal static class UIHelper
    {
        // UI状態設定
        public static void SetUIEnabled(Form form, bool enabled, Cursor cursor)
        {
            form.Cursor = cursor;
            foreach (Control control in form.Controls)
            {
                if (control is TabControl)
                {
                    continue;
                }
                control.Enabled = enabled;
            }
        }
    }
}
