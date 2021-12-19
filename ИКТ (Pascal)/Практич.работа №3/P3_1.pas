    {Тимушев 142гр}
Program P3_1;
uses crt;
var a,b,x,y: real;
begin
writeln('y:=a/b*ln(x*x+1)/ln(10)-(b+a)/2*ln(x*x/2+1)/ln(10)+4/3*(b*b*b)');
write('A='); readln(a);
write('B='); readln(b);
if b=0 then writeln('Введите другое значение B')
else begin write('X='); readln(x);
y:=a/b*ln(x*x+1)/ln(10)-(b+a)/2*ln(x*x/2+1)/ln(10)+4/3*(b*b*b);
writeln('Y=',y);
end;
end.

