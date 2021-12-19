{Тимушев 142гр}
Program P6_2;
uses crt;
var n,i:integer;
begin
n:=1;
while n<100000 do
begin
n:=n*3;
i:=i+1;
end;
writeln('Ответ:',i);
end.