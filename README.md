[Modify 3e6a22e](https://github.com/luojunyuan/TransparentWindowChromeWithChildWindow/commit/3e6a22ec1757c216711510129b1fc6c8a3e8fc96)

[WPF-制作支持点击穿透的高性能的透明背景异形窗口](https://blog.lindexi.com/post/WPF-制作支持点击穿透的高性能的透明背景异形窗口.html)

基于博客代码，增加的代码，子窗口相关复现都在 MainWindow.xaml.cs 的构造函数

克隆直接运行起来，会启动 edge

正常预期的样子：
<img width="801" height="811" alt="image" src="https://github.com/user-attachments/assets/04d4a9a7-8a41-451a-bc8a-c46a7056f45c" />

打开csproj，切换到net48，再次运行

非预期的样子，layerd没有被正常添加
<img width="789" height="823" alt="image" src="https://github.com/user-attachments/assets/6474f199-3402-466c-93e0-c5073fec6d2d" />

Note：观察到 net48 下在消息事件钩子里，WM_STYLECHANGED 改变完成的消息不再触发
