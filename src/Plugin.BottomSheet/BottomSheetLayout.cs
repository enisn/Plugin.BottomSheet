using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Plugin.BottomSheet
{
    [ContentProperty(nameof(Content))]
    public class BottomSheetLayout : RelativeLayout
    {
        private View bottomSheetContent;
        private readonly Frame bottomFrame;
        private readonly StackLayout bottomContainer = new StackLayout { };
        private readonly ContentView pageContainer = new ContentView { Padding = 0, Margin = 0 };
        public BottomSheetLayout()
        {
            bottomFrame = new Frame
            {
                CornerRadius = 8,
                HasShadow = true,
                Padding = 5,
                Content = bottomContainer
            };
            var recognizer = new PanGestureRecognizer();
            recognizer.PanUpdated += Recognizer_PanUpdated;
            bottomFrame.GestureRecognizers.Add(recognizer);

            this.Children.Add(pageContainer, xConstraint: null, yConstraint: null, null, null);
            this.Children.Add(bottomFrame,
                yConstraint: Constraint.RelativeToParent(p => p.Height * .95),
                widthConstraint: Constraint.RelativeToParent(p => p.Width),
                heightConstraint: Constraint.RelativeToParent(p => p.Height * .95)
                );
        }

        public View Content { get => pageContainer.Content; set => pageContainer.Content = value; }
        public View BottomSheetContent
        {
            get => bottomSheetContent;
            set { bottomSheetContent = value; InitBottomSheet(); }
        }

        public virtual View GenerateAnchor()
        {
            return new BoxView
            {
                HeightRequest = 5,
                CornerRadius = 2,
                WidthRequest = 50,
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.Center
            };
        }

        private void InitBottomSheet()
        {
            bottomContainer.Children.Clear();
            bottomContainer.Children.Add(GenerateAnchor());
            bottomContainer.Children.Add(BottomSheetContent);
            bottomFrame.BackgroundColor = BottomSheetContent.BackgroundColor;
        }

        private void Recognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    bottomFrame.TranslateTo(bottomFrame.X, bottomFrame.TranslationY + e.TotalY, 50);
                    break;
                case GestureStatus.Completed:
                case GestureStatus.Canceled:
                    if (Math.Abs(bottomFrame.TranslationY) > Height * .2)
                    {
                        bottomFrame.TranslateTo(bottomFrame.X, -(Height * 0.90));
                    }
                    else
                    {
                        bottomFrame.TranslateTo(bottomFrame.X, 0);
                    }
                    break;
            }
        }
    }
}
