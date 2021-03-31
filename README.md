# Thrift-Demonstration-Chemical-Elements

Simple project that demonstrates C#/.NET Thrift client-server communication

Model changes have to be done in PElementCore\PElementService.thrift file.
To apply the changes to C# code you need to run the following command in PowerShell:
.\thrift-0.14.1.exe -gen netstd -o PElementCore PElementCore\PElementService.thrift
