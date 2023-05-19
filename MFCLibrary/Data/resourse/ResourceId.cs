using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Data.resourse
{
    internal enum ResourceId
    {
        //Global
        choosenAnAction = 1,
        login = 2,
        password = 3,
        inputError = 4,
        actionError = 5,
        inputErrorTwo = 6,
        foundEmployeeError = 7,
        foundServiceError = 8,
        foundClientError = 9,
        solutationTypeDate = 10,
        actionErrorTwo = 11,
        dateError = 12,
        errorTakeTime = 13,
        renderedServices = 14,
        newPassword = 15,
        timeError = 16,
        ticket = 17,
        service = 18,
        window = 19,
        employee = 20,
        client = 21,
        fullName = 22,
        passport = 23,
        birthday = 24,
        name = 25,
        //Authorization
        questionAboutAccount = 101,
        createNewAccount = 102,
        //Menu authorization
        firstEntry = 201,
        //Main menu
        welcome = 301,
        salutation = 302,
        //Setting menu
        titleSetting = 401,
        salutationSettings = 402,
        salutationThemes = 403, 
        titleSettingThemes = 404,
        //Menu add servicing
        solutationTypeClient = 501,
        //Menu add client
        typesClient = 601,
        //Add authorized Servicing
        addOperationServicing = 701,
        erorTypeClient = 702,
        //Take data
        takeWindowNumber = 801,
        takeServiceId = 802,
        takeClientId = 803,
        takeDate = 804,
        takeUsualTime = 805,
        takeTime = 806,
        takeFullname = 807,
        takePassport = 808,
        takeEmail = 809,
        takeBirthday = 810,
        takeEmployeeId = 811,
        takeNameService = 812,
        takeTicket = 813,
        //Print names
        services = 901,
        clients = 902,
        employees = 903,
        //Add client
        addClient = 1001,
        errorAddClient = 1002,
        //Change client
        takeNewPassport = 1101,
        changeClientCompleate = 1102,
        //Search client
        searchCriteria = 1201,
        clientData = 1202,
        //Add employee
        takeWindow = 1301,
        errorTakeWindow = 1302,
        addEmployee = 1303,
        //Change employee
        changeEmployeeCompleate = 1401,
        //Delete employee
        deleteEmployeeCompleate = 1501,
        //Add service
        addServiceCompleate = 1601,
        //Delete service
        deleteServiceError = 1701,
        deleteServiceCompleate = 1702,
        //Menu setting languages
        salutationLanguage = 1801,
        //Add servicing
        addServicingCompleate = 1901,
        salutationDateTime = 1902,
        //SearchServicing
        searchCriteriaServicing = 2001,
        //View servicing statistics
        variantsSearchServicing = 2101,
        statisticUsualClients = 2102,
        statisticAuthorizedClients = 2103,
        from = 2104,
        before = 2105,
        statisticWindow = 2106,
        averageLoad = 2107,
        perHour = 2108,
        perDay = 2109,
        perWeek = 2110,
        perMonth = 2111,
        perYear = 2112,
        inTotal = 2113
    }
}
