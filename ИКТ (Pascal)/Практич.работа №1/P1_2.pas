   {Тимушев Федор 142гр}
program P1_2;
uses crt;
var a, b, c: integer; {исходное значение}
    label 1;
begin
     goto 1;
     writeln('Исходные значения: ');
     a:=10; {исходное значение}
     writeln('A=', a);
     b:=2; {исходное значение}
     writeln('B=', b);
     c:=-6; {исходное значение}
     writeln('C=', c);
     writeln;
     writeln('Результаты: ');
  1: A:=B*C-9;
     Writeln('A=B*C-9');
     Writeln('A= ',A);
     B:=6+C;
     C:=3*A+2*B;
     A:=B-C;
     Writeln('A=B-C');
     Writeln('A= ',A);
     Writeln('B=6+C');
     Writeln('B= ',B);
     Writeln('C=3*A+2*B');
     Writeln('C= ',C);
end. {конец программы}