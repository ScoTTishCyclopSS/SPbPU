var f = +prompt("Введите минимальный элемент массива"); 
var l = +prompt("Введите верхнюю границу для массива"); 
var w = +prompt("Введите шаг массива"); 
var array = new Array(); 
for (i=f; i<=l; i+=w)
	array.push(i);
document.write("Минимальный эелемент: "+ f + "<br>"); 
document.write("Верхний эелемент: "+ l + "<br>"); 
document.write("Шаг: "+ w + "<br>"); 
document.write("Массив:<br>");
document.write(array.join(","));
array.push(1); 
document.write("<br><br>Массив с 1 на конце: <br>");
document.write(array.join(","));