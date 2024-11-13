### Panduan Untuk Menjalankan Aplikasi
1. Restore dulu semua package untuk memastikan semua package ada saat akan digunakan
2. Jalankan script "dotnet ef migrations init" setelah itu "dotnet ef database update" untuk melakukan inisialisasi db pertama kali
3. setelah itu jalankan "dotnet run" untuk menjalankan aplikasi, dan akan redirect otomatis ke localhost:5116 dan tambahkan "/swagger" apabila swagger tidak muncul