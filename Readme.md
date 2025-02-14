todolist: 

Перенести логику крутки рулетки, чтобы при реквесте в SpineController происходила крутка рулетки и пользователь выигрывал либо проигрывал. 
И баланс пользователя менялся. +
как сделать так чтобы при изменении кода сервер сам перезапускался
научить Диму дебажить .Net приложение
сделать валидацию для всех ставок - скопировать логику с консольного приложения

public object getCoefficient(string attribute)
{
    switch (attribute)
    {
        case "number":
            return 36;
        case "even":
            return 2;
        case "color":
            return 2;
        case "row":
            return 12;
        case "column":
            return 3;
        case "rank":
            return 2;
        case "sequence":
            return 3;
        default:
            return "There is no such an attribute";
    }
}

перепровер правильность коеффициентов