using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Data.resourse
{
    internal class Ru
    {
        internal static Dictionary<ResourceId, string> resourcesRu = new Dictionary<ResourceId, string>
        {
            { ResourceId.welcome, "Приветствуем вас в меню базы данных отделения МФЦ." },
            { ResourceId.salutation, "1. Добавить нового сотрудника\n" +
                "2. Добавить нового клиента\n" +
                "3. Добавить услугу\n" +
                "4. Добавить информацию об обслуживании клиентов\n" +
                "5. Редактировать данные о сотруднике\n" +
                "6. Редактировать данные о клиенте\n" +
                "7. Поиск клиента\n" +
                "8. Поиск операции обслуживания\n" +
                "9. Просмотр статистики обслуживания\n" +
                "10. Удаление сотрудника из базы\n" +
                "11. Удаление услуги\n" +
                "12. Настройки\n" +
                "0. Выход из приложения"},
            {ResourceId.choosenAnAction, "Выбор действия" },
            {ResourceId.firstEntry, "Это ваш первый заход в приложение. Необходимо создать аккаунт." },
            {ResourceId.questionAboutAccount, "Хотите зайти под этим аккаунтом?\n1.Да\n2.Нет" },
            {ResourceId.login, "Логин" },
            {ResourceId.password, "Пароль" },
            {ResourceId.createNewAccount, "Создан новый аккаунт" },
            {ResourceId.inputError, "Ошибка ввода. Попробуйте ввести снова." },
            {ResourceId.actionError, "Необходимо выбрать действие" },
            {ResourceId.foundEmployeeError, "Сотрудника с такими данными нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.foundServiceError, "Данной услуги нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>"},
            {ResourceId.foundClientError, "Клиента с такими данными нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.inputErrorTwo, "Ошибка ввода. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.erorTypeClient, "Данный клиент не был зарегистрирован через ГосУслуги. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.titleSetting, "Настройки" },
            {ResourceId.salutationSettings, "1. Сменить тему\n" +
                "2. Добавить новый аккаунт\n" +
                "3. Изменить пароль\n" +
                "4. Изменить язык\n" +
                "0. Назад" },
            {ResourceId.titleSettingThemes, "Настройки, выбор темы." },
            {ResourceId.salutationThemes, "1. Стандартная(Ч/Б)\n" +
                "2. Токсичная(З/Б)\n" +
                "3. Токсичная2(ТЗ/С)\n" +
                "4. Жёлтая(ТЖ/ТС)\n" +
                "0. Назад"},
            {ResourceId.solutationTypeClient, "Типы регистрации клиентов:\n1.Обычная\n2.Через ГосУслуги\n"},
            {ResourceId.addOperationServicing, "Операция обслуживания была добавлена" },
            {ResourceId.takeWindowNumber, "Введите номер окна обслуживания(формат Г**, где * - номер окна обслуживания)" },
            {ResourceId.takeServiceId, "Введите ID услуги" },
            {ResourceId.takeClientId, "Введите ID клиента" },
            {ResourceId.takeDate, "Введите дату (формат ДД.ММ.ГГГГ)" },
            {ResourceId.takeTime, "Введите назначенное время (Время приёма от 9:00 до 19:00, с промежутком в 15 минут)" },
            {ResourceId.services, "Услуги" },
            {ResourceId.clients, "Клиенты" },
            {ResourceId.solutationTypeDate, "1. Текущая дата\n2. Своя дата" },
            {ResourceId.actionErrorTwo, "Необходимо выбрать действие. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.dateError, "Операции обслуживания не могут быть записаны на выходные дни. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.errorTakeTime, "Данное время уже занято другой операцией обслуживания. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.addClient, "Клиент добавлен в базу данных" },
            {ResourceId.takeFullname, "Введите ФИО" },
            {ResourceId.takePassport, "Введите паспортные данные (формат СССС НННННН, где С – цифры серии, Н – цифры номера паспорта)" },
            {ResourceId.errorAddClient, "Клиент с такими паспортными данными уже числится в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.takeEmail, "Введите адрес электронной почты (формат «username@host.domain»)" },
            {ResourceId.takeNewPassport, "Введите новые паспортные данные (формат СССС НННННН, где С – цифры серии, Н – цифры номера паспорта)" },
            {ResourceId.changeClientCompleate, "Данные клиента изменены" },
            {ResourceId.searchCriteria, "Критерии поиска клиента:\n1.ФИО\n2.Паспортные данные" },
            {ResourceId.clientData, "Данные клиента" },
            {ResourceId.renderedServices, "Оказанные услуги" },
            {ResourceId.takeBirthday, "Введите дату рождения (формат ДД.ММ.ГГГГ)" },
            {ResourceId.takeWindow, "Введите номер окна обслуживания (от 1 до 23)" },
            {ResourceId.errorTakeWindow, "Данное окно обслуживания уже числится за другим сотрудником. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.addEmployee, "Сотрудник добавлен в базу данных" },
            {ResourceId.takeEmployeeId, "Введите ID сотрудника" },
            {ResourceId.changeEmployeeCompleate, "Данные сотрудника изменены" },
            {ResourceId.deleteEmployeeCompleate, "Сотрудник удалён из базы данных" },
            {ResourceId.takeNameService, "Введите название услуги" },
            {ResourceId.addServiceCompleate, "Услуга добавлена в базу данных" },
            {ResourceId.deleteServiceError, "Данная услуга уже оказывалась и не может быть удалена из базы данных. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.deleteServiceCompleate, "Услуга удалена из базы данных" },
            {ResourceId.salutationLanguage, "1. Русский язык\n2. Английский язык" },
            {ResourceId.newPassword, "Новый пароль" },
            {ResourceId.addServicingCompleate, "Операция обслуживания была добавлена" },
            {ResourceId.employees, "Сотрудники" },
            {ResourceId.salutationDateTime, "1. Текущие дата и время\n2. Свои дата и время" },
            {ResourceId.takeUsualTime, "Введите время (формат ЧЧ:ММ)" },
            {ResourceId.timeError, "Необходимо ввести время в промежутке от 9:00 до 19:00. Попробуйте ввести снова, либо вернитесь в меню: <...>" },
            {ResourceId.searchCriteriaServicing, "Критерии поиска операции обслуживания:\n1.ФИО клиента\n2.ФИО сотрудника\n3.Дата обслуживания и номер талона" },
            {ResourceId.takeTicket, "Введите номер талона (формат XNNN: X - первая буква наименования услуги, N – порядковый номер талона за текущий день)" },
            {ResourceId.ticket, "Талон" },
            {ResourceId.service, "Услуга" },
            {ResourceId.window, "Окно" },
            {ResourceId.employee, "Сотрудник" },
            {ResourceId.client, "Клиент" },
            {ResourceId.variantsSearchServicing, "Варианты поиска:\n1.Дата\n2.Диапазон дат\n3.По окнам МФЦ\n4.Вся статистика" },
            {ResourceId.statisticUsualClients, "Статистика обслуживания обычных пользователей" },
            {ResourceId.statisticAuthorizedClients, "Статистика обслуживания верифицированных пользователей (ГосУслуги)" },
            {ResourceId.from, "От" },
            {ResourceId.before, "До" },
            {ResourceId.statisticWindow, "Статистика обслуживания окна" },
            {ResourceId.averageLoad, "Средняя нагруженность" },
            {ResourceId.perHour, "За час" },
            {ResourceId.perDay, "В день" },
            {ResourceId.perWeek, "В неделю" },
            {ResourceId.perMonth, "В месяц" },
            {ResourceId.perYear, "В год" },
            {ResourceId.inTotal, "Всего" },
            {ResourceId.fullName, "ФИО" },
            {ResourceId.passport, "Паспорт" },
            {ResourceId.birthday, "День рождения" },
            {ResourceId.name, "Наименование" }
        };
    }
}
