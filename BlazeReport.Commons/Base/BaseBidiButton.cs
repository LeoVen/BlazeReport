using Microsoft.AspNetCore.Components;
using System;

namespace BlazeReport.Commons.Base
{
    public abstract class BaseBidiButton : ComponentBase
    {
        /// <summary>
        /// The Id of the button element
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// A callback function that handles an OnClick event that can be caused by either a Left click or a Right click of the mouse.
        /// </summary>
        [Parameter]
        public Action<ClickType> OnClick { get; set; }

        /// <summary>
        /// The content to be within the button
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The two main events from a mouse
        /// </summary>
        public enum ClickType
        {
            LEFT_CLICK,
            RIGHT_CLICK
        }
    }
}
