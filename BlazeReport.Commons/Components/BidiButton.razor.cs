using BlazeReport.Commons.Base;
using Microsoft.AspNetCore.Components.Web;

namespace BlazeReport.Commons.Components
{
    public partial class BidiButton : BaseBidiButton
    {
        void HandleRightClick(MouseEventArgs args)
        {
            if (args.Button == 2)
            {
                OnClick?.Invoke(BaseBidiButton.ClickType.RIGHT_CLICK);
            }
        }

        void HandleLeftClick(MouseEventArgs args)
        {
            OnClick?.Invoke(BaseBidiButton.ClickType.LEFT_CLICK);
        }
    }
}
