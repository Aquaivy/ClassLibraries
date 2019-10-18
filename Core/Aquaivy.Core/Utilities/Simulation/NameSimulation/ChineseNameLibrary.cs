﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Core.Utilities
{
    /// <summary>
    /// 中文所有姓氏
    /// </summary>
    public class ChineseNameLibrary
    {
        /// <summary>
        /// 
        /// </summary>
        public const int FamilyLength = 434;

        /// <summary>
        /// 百家姓（单字，434个）
        /// </summary>
        public static string[] Family = new string[] {
"赵","钱","孙","李","周","吴","郑","王","冯","陈","褚","卫","蒋","沈","韩","杨",
"朱","秦","尤","许","何","吕","施","张","孔","曹","严","华","金","魏","陶","姜",
"戚","谢","邹","喻","柏","水","窦","章","云","苏","潘","葛","奚","范","彭","郎",
"鲁","韦","昌","马","苗","凤","花","方","俞","任","袁","柳","酆","鲍","史","唐",
"费","廉","岑","薛","雷","贺","倪","汤","滕","殷","罗","毕","郝","邬","安","常",
"乐","于","时","傅","皮","卞","齐","康","伍","余","元","卜","顾","孟","平","黄",
"和","穆","萧","尹","姚","邵","舒","汪","祁","毛","禹","狄","米","贝","明","臧",
"计","伏","成","戴","谈","宋","茅","庞","熊","纪","屈","项","祝","董","杜","阮",
"蓝","闵","席","季","麻","强","贾","路","娄","危","江","童","颜","郭","梅","盛",
"林","刁","钟","徐","邱","骆","高","夏","蔡","田","樊","胡","凌","霍","虞","万",
"支","柯","咎","管","卢","莫","经","房","裘","缪","干","解","应","宗","宣","丁",
"贲","邓","郁","单","杭","洪","包","诸","左","石","崔","吉","钮","龚","程","嵇",
"邢","滑","裴","陆","荣","翁","荀","羊","於","惠","甄","加","封","芮","羿","储",
"靳","汲","邴","糜","松","井","段","富","巫","乌","焦","巴","弓","牧","隗","山",
"谷","车","侯","宓","蓬","全","郗","班","仰","秋","仲","伊","宫","宁","仇","栾",
"暴","甘","钭","厉","戎","祖","武","符","刘","詹","束","龙","叶","幸","司","韶",
"郜","黎","蓟","薄","印","宿","白","怀","蒲","台","从","鄂","索","咸","籍","赖",
"卓","蔺","屠","蒙","池","乔","阴","胥","能","苍","双","闻","莘","党","翟","谭",
"贡","劳","逄","姬","申","扶","堵","冉","宰","郦","雍","璩","桑","桂","濮","牛",
"寿","通","边","扈","燕","冀","郏","浦","尚","农","温","别","庄","晏","柴","瞿",
"阎","充","慕","连","茹","习","宦","艾","鱼","容","向","古","易","慎","戈","廖",
"庚","终","暨","居","衡","步","都","耿","满","弘","匡","国","文","寇","广","禄",
"阙","东","殳","沃","利","蔚","越","夔","隆","师","巩","厍","聂","晁","勾","敖",
"融","冷","訾","辛","阚","那","简","饶","空","曾","毋","沙","乜","养","鞠","须",
"丰","巢","关","蒯","相","查","后","红","游","竺","权","逯","盖","益","桓","公",
"晋","楚","法","汝","鄢","涂","钦","缑","亢","况","有","商","牟","佘","佴","伯",
"赏","墨","哈","谯","笪","年","爱","阳","佟","琴","言","福","百","家","姓","续",
"岳","帅"};

        /// <summary>
        /// 
        /// </summary>
        public const int CompoundFamilyLength = 57;

        /// <summary>
        /// 百家姓（复姓，57个）
        /// </summary>
        public static string[] CompoundFamily = new string[] {
"第五","梁丘","左丘","东门","百里","东郭","南门","呼延",
"万俟","南宫","段干","西门","司马","上官","欧阳","夏侯",
"诸葛","闻人","东方","赫连","皇甫","尉迟","公羊","澹台",
"公冶","宗政","濮阳","淳于","仲孙","太叔","申屠","公孙",
"乐正","轩辕","令狐","钟离","闾丘","长孙","慕容","鲜于",
"宇文","司徒","司空","亓官","司寇","子车","颛孙","端木",
"巫马","公西","漆雕","壤驷","公良","夹谷","宰父","微生",
"羊舌"};

        /// <summary>
        /// 
        /// </summary>
        public const int CommonLength = 2994;

        /// <summary>
        /// 常用汉字表（一级汉字表，共三级）
        /// </summary>
        public static string Common = "的一是在不了有和人这中大为上个国我以要他时来用们生到作地于出就分对成会可主发年动同工也能下过子说产种面而方后多定行学法所民得经十三之进着等部度家电力里如水化高自二理起小物现实加量都两体制机当使点从业本去把性好应开它合还因由其些然前外天政四日那社义事平形相全表间样与关各重新线内数正心反你明看原又么利比或但质气第向道命此变条只没结解问意建月公无系军很情者最立代想已通并提直题党程展五果料象员革位入常文总次品式活设及管特件长求老头基资边流路级少图山统接知较长将组见计别她手角期根论运农指几九区强放决西被干做必战先回则任取据处队南给色光门即保治北造百规热领七海地口东导器压志世金增争济阶油思术极交受联什认六共权收证改清已美再采转更单风切打白教速花带安场身车例真务具万每目至达走积示议声报斗完类八离华名确才科张信马节话米整空元况今集温传土许步群广石记需段研界拉林律叫且究观越织装影算低持音众书布复容儿须际商非验连断深难近矿千周委素技备半办青省列习响约支般史感劳便团往酸历市克何除消构府称太准精值号率族维划选标写存候毛亲快效斯院查江型眼王按格养易置派层片始却专状育厂京识适属圆包火住调满县局照参红细引听该铁价严首底液官德调随病苏失尔死讲配女黄推显谈罪神艺呢席含企望密批营项防举球英氧势告李台落木帮轮破亚师围注远字材排供河态封另施减树溶怎止案言士均武固叶鱼波视仅费紧爱左章早朝害续轻服试食充兵源判护司足某练差致板田降黑犯负击范继兴似余坚曲输修的故城夫够送笔船占右财吃富春职觉汉画功巴跟虽杂飞检吸助升阳互初创抗考投坏策古径换未跑留钢曾端责站简述钱副尽帝射草冲承独令限阿宣环双请超微让控州良轴找否纪益依优顶础载倒房突坐粉敌略客袁冷胜绝析块剂测丝协重诉念陈仍罗盐友洋错苦夜刑移频逐靠混母短皮终聚汽村云哪既距卫停烈央察烧行迅境若印洲刻括激孔搞甚室待核校散侵吧甲游久菜味旧模湖货损预阻毫普稳乙妈植息扩银语挥酒守拿序纸医缺雨吗针刘啊急唱误训愿审附获茶鲜粮斤孩脱硫肥善龙演父渐血欢械掌歌沙著刚攻谓盾讨晚粒乱燃矛乎杀药宁鲁贵钟煤读班伯香介迫句丰培握兰担弦蛋沉假穿执答乐谁顺烟缩征脸喜松脚困异免背星福买染井概慢怕磁倍祖皇促静补评翻肉践尼衣宽扬棉希伤操垂秋宜氢套笔督振架亮末宪庆编牛触映雷销诗座居抓裂胞呼娘景威绿晶厚盟衡鸡孙延危胶还屋乡临陆顾掉呀灯岁措束耐剧玉赵跳哥季课凯胡额款绍卷齐伟蒸殖永宗苗川炉岩弱零杨奏沿露杆探滑镇饭浓航怀赶库夺伊灵税了途灭赛归召鼓播盘裁险康唯录菌纯借糖盖横符私努堂域枪润幅哈竟熟虫泽脑壤碳欧遍侧寨敢彻虑斜薄庭都纳弹饲伸折麦湿暗荷瓦塞床筑恶户访塔奇透梁刀旋迹卡氯遇份毒泥退洗摆灰彩卖耗夏择忙铜献硬予繁圈雪函亦抽篇阵阴丁尺追堆雄迎泛爸楼避谋吨野猪旗累偏典馆索秦脂潮爷豆忽托惊塑遗愈朱替纤粗倾尚痛楚谢奋购磨君池旁碎骨监捕弟暴割贯殊释词亡壁顿宝午尘闻揭炮残冬桥妇警综招吴付浮遭徐您摇谷赞箱隔订男吹乐园纷唐败宋玻巨耕坦荣闭湾键凡驻锅救恩剥凝碱齿截炼麻纺禁废盛版缓净睛昌婚涉筒嘴插岸朗庄街藏姑贸腐奴啦惯乘伙恢匀纱扎辩耳彪臣亿璃抵脉秀萨俄网舞店喷纵寸汗挂洪着贺闪柬爆烯津稻墙软勇像滚厘蒙芳肯坡柱荡腿仪旅尾轧冰贡登黎削钻勒逃障氨郭峰币港伏轨亩毕擦莫刺浪秘援株健售股岛甘泡睡童铸汤阀休汇舍牧绕炸哲磷绩朋淡尖启陷柴呈徒颜泪稍忘泵蓝拖洞授镜辛壮锋贫虚弯摩泰幼廷尊窗纲弄隶疑氏宫姐震瑞怪尤琴循描膜违夹腰缘珠穷森枝竹沟催绳忆邦剩幸浆栏拥牙贮礼滤钠纹弹罢拍咱喊袖埃勤罚焦潜伍墨欲缝姓刊饱仿奖铝鬼丽跨默挖链扫喝袋炭污幕诸弧励梅奶洁灾舟鉴苯讼抱毁率懂寒智埔寄届跃渡挑丹艰贝碰拔爹戴码梦芽熔赤渔哭敬颗奔藏铅熟仲虎稀妹乏珍申桌遵允隆螺仓魏锐晓氮兼隐碍赫拨忠肃缸牵抢博巧壳兄杜讯诚碧祥柯页巡矩悲灌龄伦票寻桂铺圣恐恰郑趣抬荒腾贴柔滴猛阔辆妻填撤储签闹扰紫砂递戏吊陶伐喂疗瓶婆抚臂摸忍虾蜡邻胸巩挤偶弃槽劲乳邓吉仁烂砖租乌舰伴瓜浅丙暂燥橡柳迷暖牌纤秧胆详簧踏瓷谱呆宾糊洛辉愤竞隙怒粘乃绪肩籍敏涂熙皆侦悬掘享纠醒狂锁淀恨牲霸爬赏逆玩陵祝秒浙貌役彼悉鸭着趋凤晨畜辈秩卵署梯炎滩棋驱筛峡冒啥寿译浸泉帽迟硅疆贷漏稿冠嫩胁芯牢叛蚀奥鸣岭羊凭串塘绘酵融盆锡庙筹冻辅摄袭筋拒僚旱钾鸟漆沈眉疏添棒穗硝韩逼扭侨凉挺碗栽炒杯患馏劝豪辽勃鸿旦吏拜狗埋辊掩饮搬骂辞勾扣估蒋绒雾丈朵姆拟宇辑陕雕偿蓄崇剪倡厅咬驶薯刷斥番赋奉佛浇漫曼扇钙桃扶仔返俗亏腔鞋棱覆框悄叔撞骗勘旺沸孤粘吐孟渠屈疾妙惜仰狠胀谐抛霉桑岗嘛衰盗渗脏赖涌甜曹阅肌哩厉烃纬毅昨伪症煮叹钉搭茎笼酷偷弓锥恒杰坑鼻翼纶叙狱逮罐络棚抑膨蔬寺骤穆冶枯册尸凸绅坯牺焰轰欣晋瘦御锭锦丧旬锻垄搜佛扑邀亭酯迈舒脆酶闲忧酚顽羽涨卸仗陪薄辟惩杭姚肚捉飘漂昆欺吾郎烷汁呵饰萧雅邮迁燕撒姻赴宴烦削债帐斑铃旨醇董饼雏姿拌傅腹妥揉贤拆歪葡胺丢浩徽昂垫挡览贪慰缴汪慌冯诺姜谊凶劣诬耀昏躺盈骑乔溪丛卢抹易闷咨刮驾缆悟摘铒掷颇幻柄惠惨佳仇腊窝涤剑瞧堡泼葱罩霍捞胎苍滨俩捅湘砍霞邵萄疯淮遂熊粪烘宿档戈驳嫂裕徙箭捐肠撑晒辨殿莲摊搅酱屏疫哀蔡堵沫皱畅叠阁莱敲辖钩痕坝巷饿祸丘玄溜曰逻彭尝卿妨艇吞韦怨矮歇郊禄捻漠粹颠宏冤肪饥呵仙押挨醛娃拾没佩勿吓讹侯恋夕锌篡戚淋蓬岂釉兆泊魂拘亡杠摧氟颂浑凌铀诱犁谴颁舶扯嘉萌犹滋焊舌匹媳肺掠酿烹疲驰鸦窄辱狭朴遣菲奸韧辣拳秆卧醉竭茅墓矣哎艳敦舆缔雇尿葬履契禽渣衬躲赔咸溉贼醋堤抖妃裤廉晴挽掀茫丑亥拦悠阐慧佐奇竖孝柜麟绣遥逝愁肖昭芬逢窑捷圜盲闸宙辐披账狼幽绸蜂慎餐酬誓惟叉弥址帜芝砌唉仆涛臭翠盒劫慨炳阖寂椒倘拓畏喉巾颈垦拚兽蔽芦乾爽窃谭挣崩模褐传翅儒伞晃谬胚剖凑眠浊霜礁蔑抄闯洒碑蓉耶猜蹲壶唤澳锯郡玲绵纽梳掏吁锤鼠穴椅殷遮吵萍厌畜俱夸吕囊捧雌闽饶瞬郁哨凿朝俺浒茂肝勋盯籽耻菊滥稼戒奈帅鞭蚕镁询跌烤坛宅笛鄂蛮颤棍睁鼎岌降侍藩嚷匪岳糟缠迪泄卑氛堪萝盛碘缚悦澄甫攀屠溢拱晰携朽吟菱谦凹俊芒盼婶艘酰趁唇挫羞浴疼萎肴愚肿刨绞枢嫁慕舱铲苹豫谕迭潘顷翁榜匠欠茬畴胃沾踪弊哼鹏歧桐沃悼惑溃蔗荐潭孢露诊庸聪嫌厨庞祁钳肆梭赠崖篮颖甸藻捣且撕诏贞赐慈炕胖兹差琼锈汛卓棵馈挠灶婴蒂肤衫沥仑勉沪逸蜜浦嗓晕膏祭赢艾扮鹅怜蒲兔孕呖蘖挪淑谣惧廊缅俘骄膀陡宰诞峻恼腺猎涡夷愉魔铵葛贾似荫哟脊钞苛锰椭镶杏溴倚滞会氓捏斩傲匆僵卤烫衍榨拢裸屑咽坊舅渴翔邪拄窖猫砌钦媒脾勺柏栅噪昼耿扁辰秤得贩糕梁昙衷宦扔哇诈嘱藤卜冈悔廓皂拐氰杉玛矢寓瓣罕垮笋淘衔称恭喇帕桉秉帘铭蛇摔斋叭帆裸俭瘤篷砸肢辟脖瞪暑卜竿歼笙酮蕴哗瞎喀刃楔喘枚嵌挝厢粤甩拴膝恳腕娓熄锚忌愧哦荆圃骚丸蒜毯弗俯鹿梢屯衙轿贱垒谅踢哑滔渥饷泳棕熬搁腈梨吻樱奠捆姨柏聘惕郓绑冀裹酥寡彦稠啡钝汝擅汰鳙埔敞嘿逊栋谨咖鲤雀佣庵葫贿鳞拼搏谎塌忉腻戊怖坟禾刹嘻桔坎拇煽狮痒曾梗寇鹰烛哄莽雯胳龟亟糠泌坪傻什喻渊蚌跪巷涅钊譬蕊膛侮奕枕辫况扼郝寥凄厦腥钧耦蹄戥屁诵匈桩钓涵倦袍抒屿蹈忿敷虹聊嗣尉灿糙蹬嗯姬狡笨辜僧茨讽翰枉岐枣崭焚咕猴揽涝耍趟汹咋傍镀给爵虏劈璋踩瞅迄昔汞呱诡魄祺嘲惶赃癌咐歉扳鄙庐聂便芡躯贬煌拧隋襄淤宠炊滇謇懒栓佑憾骆裙猖兜孵痼盥曝泣絮韵眷旷噢参栖盏鳌溅煎校榴暮琪淆陛巢哒吼槐唧其沛乞蜀蜇赚捍铰幂尧咒耽叮褂焕煞雹搓釜铬拣募淹瑰鲢茄灼邹躬觉娇焉彰鹤琳沦畔惹庶毙皖邢禹渍绷窜翘淫箪陌膊鞑咳玫巫拂蕉澜赎绥锄囱赌颊缕寅躁稚庚苟氦魁珊蜕蛭酌逗闺蔓撇豌朕缉襟镍桅荧侄卒佃瞿娶饪耸乍靶痴靖扛筐韶嚣崔蓿岔氘娥剿霖喃搪雍裳撰豹骏慷";
    }
}
