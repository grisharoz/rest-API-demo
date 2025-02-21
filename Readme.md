todolist:

Перенести логику крутки рулетки, чтобы при реквесте в SpineController происходила крутка рулетки и пользователь выигрывал либо проигрывал. И баланс пользователя менялся. + как сделать так чтобы при изменении кода сервер сам перезапускался научить Диму дебажить .Net приложение сделать валидацию для всех ставок - скопировать логику с консольного приложения

public object getCoefficient(string attribute) { switch (attribute) { case "number": return 36; case "even": return 2; case "color": return 2; case "row": return 12; case "column": return 3; case "rank": return 2; case "sequence": return 3; default: return "There is no such an attribute"; } }

перепровер правильность коеффициентов

Создать класс и экстендить его от BetsDTO, добавив дополнительный аттрибут "выиграл или проиграл". Его нужно вернуть при ендпоинте /spin. То есть я отправляю тебе такой реквест

[ { "Type": "number", "Value": "7", "Stake": 50 }, { "Type": "color", "Value": "red", "Stake": 100 } ]

а ты мне отправляешь такой ответ

[ { "Type": "number", "Value": "7", "Stake": 50, "Win": True }, { "Type": "color", "Value": "red", "Stake": 100, "Win": True } ]

Почитать иммутабельности в си шарпе.

--- 

1. протестировать
2. Прочитать про деплой .Net приложения, Прочитать про докер