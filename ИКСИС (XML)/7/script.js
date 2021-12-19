var today = new Date(),
    day;

//Опции вывода
var openDate = {
    year: 'numeric',
    month: 'long',
    day: 'numeric'
},  
    todayTime = {
    timezone: 'UTC',
    hour: 'numeric',
    minute: 'numeric',
    second: 'numeric'
};

switch(today.getDay()) {
    case 0: day = "понедельник"; break;
    case 1: day = "вторник";     break;
    case 2: day = "среда";       break;
    case 3: day = "четверг";     break;
    case 4: day = "пятница";     break;
    case 5: day = "суббота";     break;
    case 6: day = "воскресенье"; break;
}

var openInput        = document.getElementById("openDate"),
    hours            = document.getElementById("hours"),
    minutes          = document.getElementById("minutes"),
    seconds          = document.getElementById("sec");
    todayDay         = document.getElementById("todayDay"),
    todayTimeInput   = document.getElementById("todayTime"),
    inputDay         = document.getElementById("day");

    openInput.innerHTML          = today.toLocaleString("ru", openDate);
    hours.innerHTML              = today.getHours();
    minutes.innerHTML            = today.getMinutes();
    seconds.innerHTML            = today.getSeconds();
    todayDay.value               = day;
    inputDay.value               = rem();

setInterval(function()
{
    var time = new Date();
    todayTimeInput.value     = time.toLocaleString("ru", todayTime);
}, 1000);


function rem() 
{
    var day = new Date(2017, 11, 31, 23, 59, 60);
    if(day < today) 
    {
        var remaining = today - day; //миллисекунды
        remaining /= 1000; //секунды
        remaining /= 60; //минуты
        remaining /= 60; //часы
        remaining /= 24; //дни
        return Math.round(remaining) + declOfNum(Math.round(remaining), [" день", " дня", " дней"]);
    } 
        else 
        {
            return " ошибка!";
        }
}

function declOfNum(number, titles) 
{
	return titles[((number%100>10 && number%100<15) || number%10>4 || number%10 == 0)? 2 : (number%10 == 1) ? 0: 1];
}