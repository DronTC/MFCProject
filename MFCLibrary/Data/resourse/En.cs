
namespace MFCLibrary.Data.resourse
{
    internal class En
    {
        internal static Dictionary<ResourceId, string> resourcesEn = new Dictionary<ResourceId, string>
        {
            { ResourceId.welcome, "Welcome to the database menu of the MFC branch." },
            { ResourceId.salutation, "1. Add a new employee\n" +
                "2. Add a new client\n" +
                "3. Add a service\n" +
                "4. Add customer service information\n" +
                "5. Edit employee data\n" +
                "6. Edit client data\n" +
                "7. Client Search\n" +
                "8. Search for a service operation\n" +
                "9. Viewing service statistics\n" +
                "10. Deleting an employee from the database\n" +
                "11. Deleting a service\n" +
                "12. Settings\n" +
                "0. Exiting the application"},
            {ResourceId.choosenAnAction, "Choosing an action" },
            {ResourceId.firstEntry, "This is your first visit to the app. You need to create an account." },
            {ResourceId.questionAboutAccount, "Do you want to log in under this account?\n1.Yes\n2.No" },
            {ResourceId.login, "Login" },
            {ResourceId.password, "Password" },
            {ResourceId.createNewAccount, "A new account has been created" },
            {ResourceId.inputError, "Input error. Try typing again." },
            {ResourceId.actionError, "You must select an action" },
            {ResourceId.foundEmployeeError, "The employee with such data is not in the database. Try typing again, or go back to the menu: <...>" },
            {ResourceId.foundServiceError, "This service is not in the database. Try typing again, or go back to the menu: <...>"},
            {ResourceId.foundClientError, "The client with such data is not in the database. Try typing again, or go back to the menu: <...>" },
            {ResourceId.inputErrorTwo, "Input error. Try typing again, or go back to the menu: <...>" },
            {ResourceId.erorTypeClient, "This client was not registered through public services. Try typing again, or go back to the menu: <...>" },
            {ResourceId.titleSetting, "Settings" },
            {ResourceId.salutationSettings, "1. Change the subject \n" +
                "2. Add a new account\n"+
                "3. Change the password\n" +
                "4. Change the language\n" +
                "0. Back" },
            {ResourceId.titleSettingThemes, "Settings, theme selection." },
            {ResourceId.salutationThemes, "1. Standard(B/W)\n" +
                "2. Toxic(S/W)\n" +
                "3. Toxic 2(TK/S)\n" +
                "4. Yellow(TJ/TS)\n" +
                "0. Back"},
            {ResourceId.solutationTypeClient, "Types of customer registration:\n1.Regular\n2.Through public services\n"},
            {ResourceId.addOperationServicing, "A maintenance operation has been added" },
            {ResourceId.takeWindowNumber, "Enter the number of the service window (format G**, where * is the number of the service window)" },
            {ResourceId.takeServiceId, "Enter the service ID" },
            {ResourceId.takeClientId, "Enter the client ID" },
            {ResourceId.takeDate, "Enter the date (format DD.MM.YYYY)" },
            {ResourceId.takeTime, "Enter the scheduled time (Reception time from 9:00 to 19:00, with an interval of 15 minutes)" },
            {ResourceId.services, "Services" },
            {ResourceId.clients, "Clients" },
            {ResourceId.solutationTypeDate, "1. Current date\n2. Own date" },
            {ResourceId.actionErrorTwo, "You must select an action. Try typing again, or go back to the menu: <...>" },
            {ResourceId.dateError, "Maintenance operations cannot be recorded on weekends. Try typing again, or go back to the menu: <...>" },
            {ResourceId.errorTakeTime, "This time is already occupied by another maintenance operation. Try typing again, or go back to the menu: <...>" },
            {ResourceId.addClient, "The client has been added to the database" },
            {ResourceId.takeFullname, "Enter your full name" },
            {ResourceId.takePassport, "Enter passport data (format SSS NNNNNN, where C is the digits of the series, H is the digits of the passport number)" },
            {ResourceId.errorAddClient, "A client with such passport data is already listed in the database. Try typing again, or go back to the menu: <...>" },
            {ResourceId.takeEmail, "Enter the email address (format «username@host.domain»)" },
            {ResourceId.takeNewPassport, "Enter the new passport data (SSSS NNNNNN format, where C is the digits of the series, H is the digits of the passport number)" },
            {ResourceId.changeClientCompleate, "Client data changed" },
            {ResourceId.searchCriteria, "Client search criteria:\n1.full name\n2.Passport data" },
            {ResourceId.clientData, "Client data" },
            {ResourceId.renderedServices, "Services rendered" },
            {ResourceId.takeBirthday, "Enter the date of birth (format DD.MM.YYYY)" },
            {ResourceId.takeWindow, "Enter the service window number (from 1 to 23)" },
            {ResourceId.errorTakeWindow, "This service window is already listed for another employee. Try typing again, or go back to the menu: <...>" },
            {ResourceId.addEmployee, "Employee added to the database" },
            {ResourceId.takeEmployeeId, "Enter the employee ID" },
            {ResourceId.changeEmployeeCompleate, "Employee data changed" },
            {ResourceId.deleteEmployeeCompleate, "The employee was removed from the database" },
            {ResourceId.takeNameService, "Enter the name of the service" },
            {ResourceId.addServiceCompleate, "The service has been added to the database" },
            {ResourceId.deleteServiceError, "This service has already been provided and cannot be deleted from the database. Try typing again, or go back to the menu: <...>" },
            {ResourceId.deleteServiceCompleate, "The service has been removed from the database" },
            {ResourceId.salutationLanguage, "1. Russian language\n2. English language" },
            {ResourceId.newPassword, "New password" },
        };
    }
}
