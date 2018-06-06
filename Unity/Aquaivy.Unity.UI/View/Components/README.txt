说明：
1.组件类图请看"UIClassDiagram.cd"文件
2.BaseElement为所有UI元素的基类，仅表示一个元素的transform信息
3.UIElement继承自BaseElement，增加了父子节点，拥有了继承关系信息
4.所有需要显示到屏幕上的组件均需继承自Graphic类
5.所有需要操作交互的组件均需继承自Selectable类


注意：
1.尽量不要开启"IMPERFECTION"条件编译符，该编译符内的代码不完善，会导致无法正确获取所有子节点信息
2.如果项目中加入了Lotus SDK，可开启"LOTUSSDK"条件编译符，此时GazeEventBridge将继承自GazeEventTrigger


讨论：
1.FrmBase是否需要继承自UIElement？如果不，UI组件的Parent如何表示？
2.在UIRootManager上AddChild一个窗体时，是否需要默认自动调用Show方法？
3.复合组件是继承自UIImage（或UIButton），还是继承自UIElement，然后实现IImageable，ISelectable等接口？孰优孰劣？
4.Form窗体的整个机制有没有更好实现方法？
5.有没有必要将UI组件再独立出来，不涉及Form，Content，Utils，Game等？
