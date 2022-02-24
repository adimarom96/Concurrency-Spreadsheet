
This is core object of a spreadsheet that can be shared between multiple concurrent users like Google Docs and Google Sheets.
The spreadsheet represent a table of n*m cells (n=rows, m=columns).
Each cell holds a string .
The spreadsheet object can be access concurrently by many users, and users can perform arbitrary operations concurrently.

To  implent this spreadsheet I used multiply locks - smephores and mutexs to avoid any deadlock or crashes during runtime, base on reader writer strategy.
In addation I created a gui interface using viusal studio to allow users easy execution for diversity action including creating / load / save spreadsheet,
edit cells, adding and rmove rows and clomnus and more.

for more info about the project you invite to contact me.

![image](https://user-images.githubusercontent.com/66023983/154854718-c5eecd02-1419-4214-aba5-22e948a73f53.png)

![image](https://user-images.githubusercontent.com/66023983/154854759-81ba7f58-4713-41d7-b136-87277fe19607.png)



