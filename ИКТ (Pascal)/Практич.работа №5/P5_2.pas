{Тимушев 142гр}
Program P5_2;
uses crt;
var a,b,c,x,y: real;
begin 
write('a=');
readln(a);
write('b=');
readln(b);
write('c=');
readln(c);
while ((4+c)=0) do
begin
writeln('Введите новое значение c');
write('c=');
readln(c);
end;
while ((2+b)=0) do
begin
writeln('Введите новое значение b');
write('b=');
readln(b);
end;
x:=(7*a*b*b+sqrt(c-1))/(4+c);
y:=(x)/sqrt(2+b)+a;
writeln('x=', x);
writeln('y=', y);
end.