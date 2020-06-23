using BlazeReport.Commons.Base;

namespace BlazeReport.Web.Pages
{
    public partial class Index
    {
        public int Counter { get; set; }

        void HandleOnClick(BaseBidiButton.ClickType type)
        {
            if (type == BaseBidiButton.ClickType.LEFT_CLICK)
            {
                Counter += 1;
            }
            else if (Counter > 0)
            {
                Counter -= 1;
            }

            StateHasChanged();
        }
    }
}
