using System.Windows.Forms;

static class Exceptions
{
    public enum ExceptionCode
    {
        SelectionStartOutOfRange = 0,
        SelectionLengthOutOfRange = 1,
        KeyFunctionDoesntExist = 2,

    }

    public static void ShowMessage(ExceptionCode code)
    {
        string message;
        switch (code)
        {
            case ExceptionCode.SelectionStartOutOfRange:
            case ExceptionCode.SelectionLengthOutOfRange:
            case ExceptionCode.KeyFunctionDoesntExist:
                message = "To fix the error, try deleting the settings file(s), then restart the application.";
                break;
            default:
                message = "Solution unknown.";
                break;
        }
        MessageBox.Show(message, "Unexpected error occured. Error code: " + (int)code);
    }
}