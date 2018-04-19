using CaseStudy.Abstracts;
using CaseStudy.Screens.Booking;
using CaseStudy.Screens.Maintenance;
using CaseStudy.Views;

namespace CaseStudy.Screens
{
    public class MenuScreen : AbstractPresenter
    {
        private const string MENU_FLIGHT_MAINTENANCE = "1";
        private const string MENU_RESERVATION = "2";
        private const string MENU_EXIT = "3";

        public MenuScreen()
        {
            this.view = new MainMenuView(this);
            ScreenManager.GetInstance().SetActiveView(this.view);
        }

        public void MenuSelected(string userInput)
        {
            switch (userInput)
            {
                case MENU_FLIGHT_MAINTENANCE:
                    ScreenManager.GetInstance().SetActivePresenter(new FlightMaintenanceScreen());
                    break;

                case MENU_RESERVATION:
                    ScreenManager.GetInstance().PushScreen(new ReservationsScreen());
                    break;

                case MENU_EXIT:
                    ScreenManager.GetInstance().PopScreen();
                    break;
            }
        }
    }
}
