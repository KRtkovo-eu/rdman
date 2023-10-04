using System.Drawing;
using System.Windows.Forms;

public class NoFocusCueButton : Button
{
    public NoFocusCueButton()
        : base()
    {
        // Prevent the button from drawing its own border
        FlatAppearance.BorderSize = 0;
        FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.SetStyle(ControlStyles.Selectable, false);
    }
}