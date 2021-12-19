{Тимушев 142гр}
Program P5_1;
uses crt;
var F,a,b: real;
begin
write('a=');
readln(a);
write('b=');
readln(b);
if (a>0) and (b>0) then
F:=power(a+b,1/3)
else
if (a<=0) and (b>0) then
F:=power(b-a,1/5)
else
if (a>0) and (b<=0) then
F:=power(a-b,1/3);
writeln('F=', F);
end.