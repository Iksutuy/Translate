using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace YutuskiTranslate
{
    public partial class Form1 : Form
    {
        public delegate void LogAppendDelegate(Color color, string text);

        private string A = "test", B = "box", C = "null";

        private int state = 1; //复制按钮状态,同翻为0则弹出选择窗口,单引擎翻译为1默认不弹出窗口
        private int EngineID;
        private int FromID;
        private int ToID;

        /// <summary>
        ///     创建主窗口并调用Setup设置控件属性
        /// </summary>
        public Form1()
        {
            //CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Setup();
            metroLabel2.Text = "提示:初始化成功";
        }

        /// <summary>
        ///     设置控件属性
        /// </summary>
        public void Setup()
        {
            //richTextBox2.ReadOnly = true;  //翻译结果框不可编辑
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //下拉框1
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList; //       2
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList; //        3只能被选择不能被修改
            CheckForIllegalCrossThreadCalls = false; //不检测跨线程调用
        }


        /// <summary>
        ///     翻译按钮 ,根据comboBox1判断翻译引擎
        ///     comboBox2.SelectedIndex设置源语言,调用TransFrom
        ///     comboBox3.SelectedIndex设置目标语言,调用TransTo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            button3.Enabled = false;
            richTextBox2.Text = null;
            Thread t1;
            t1 = new Thread(Translate);
            t1.Start();
        }


        /// <summary>
        ///     调用API获取翻译结果并返回
        /// </summary>
        private void Translate()
        {
            // MessageBox.Show("!");
            var i = comboBox1.SelectedIndex; //搜索引擎编号
            var j = comboBox2.SelectedIndex; //源语言编号
            var k = comboBox3.SelectedIndex; //目标语言编号
            var d = richTextBox1.Text.ToCharArray();
            var newStr = "";
            var newStr2 = "";
            foreach (var cr in d) //处理换行符以免JSON脚本出错
            {
                if (cr == (char)10 || cr == (char)13) //遍历字符 如过等于换行符或Enter则替换为空格+#+空格
                {
                    newStr += (char)32; //空格键
                    newStr += (char)51; //#号键
                    newStr += (char)32; //空格键
                    continue;
                }
                newStr += cr.ToString(); //将处理后的字节加入到新的字符串内
            }
            state = 1;
            switch (i) //根据不同的编号选择搜索引擎
            {
                case 0:
                    var translate1 = new Google(); //新建谷歌翻译对象
                    var sd = translate1.GoogleTranslate(newStr, TransFrom(j, i), TransTo(k, i))
                        .ToCharArray(); //将翻译返回的结果转换为字符数组
                    foreach (var cr in sd) //遍历结果
                    {
                        if (cr == (char)51) //把结果中的#重新转换为换行符
                        {
                            //newStr2 += (char)32;
                            newStr2 += (char)13; //Enter
                            continue;
                        }
                        newStr2 += cr.ToString();
                    }
                    C = newStr2;
                    显示结果(newStr2); //显示结果
                    break;
                case 1: //百度接口   _appid    _密钥
                    var translate2 = new BaiduTranslator("20171014000088294", "mxwQ2q5FS78tLiWMSZTS");
                    显示结果(C = translate2.Translate(richTextBox1.Text, TransFrom(j, i), TransTo(k, i)));
                    break;
            }
            metroLabel2.Text = "提示:翻译成功";
            button1.Enabled = true;
            button3.Enabled = true;
        }


        /// <summary>
        ///     将两个引擎的翻译结果同时显示
        /// </summary>
        private void TranslateAll()
        {
            var j = comboBox2.SelectedIndex; //源语言编号
            var k = comboBox3.SelectedIndex; //目标语言编号
            var d = richTextBox1.Text.ToCharArray();
            var newStr = "";
            var newStr2 = "";
            foreach (var cr in d) //处理换行符以免JSON脚本出错
            {
                if (cr == (char)10 || cr == (char)13) //遍历字符 如过等于换行符或Enter则替换为空格+#+空格
                {
                    newStr += (char)32; //空格键
                    newStr += (char)51; //#号键
                    newStr += (char)32; //空格键
                    continue;
                }
                newStr += cr.ToString(); //将处理后的字节加入到新的字符串内
            }
            var translate1 = new Google(); //新建谷歌翻译对象
            var sd = translate1.GoogleTranslate(newStr, TransFrom(j, 0), TransTo(k, 0)).ToCharArray(); //将翻译返回的结果转换为字符数组
            foreach (var cr in sd) //遍历结果
            {
                if (cr == (char)51) //把结果中的#重新转换为换行符
                {
                    //newStr2 += (char)32;
                    newStr2 += (char)13; //Enter
                    continue;
                }
                newStr2 += cr.ToString();
            }

            //百度接口   _appid    _密钥
            var translate2 = new BaiduTranslator("20171014000088294", "mxwQ2q5FS78tLiWMSZTS");
            var ds = translate2.Translate(richTextBox1.Text, TransFrom(j, 1), TransTo(k, 1));
            A = newStr2;
            B = ds;
            state = 0;

            显示标题("谷歌翻译:\n");
            显示结果(newStr2); //显示结果
            显示标题("\n百度翻译:\n");
            显示结果(ds); //显示结果
            metroLabel2.Text = "提示:翻译成功";
            button1.Enabled = true;
            button3.Enabled = true;
        }


        /// <summary>
        ///     调换两个文本框的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            string a;
            a = richTextBox1.Text;
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Text = a;
            metroLabel2.Text = "提示:文本框内容已调换";
        }


        /// <summary>
        ///     选择源语言
        ///     1.自动 2.中文 3.日语 4.英语 5.德语 6.法语 7.俄语 8.西班牙语
        /// </summary>
        /// <param name="IndexID"></param>
        /// <returns></returns>
        private string TransFrom(int IndexID, int IndexID2)
        {
            switch (IndexID)
            {
                case 0:
                    return "auto";
                case 1:
                    if (IndexID2 == 1)
                        return "zh";
                    else
                        return "zh-CN";
                case 2:
                    if (IndexID2 == 1)
                        return "jp";
                    else
                        return "ja";
                case 3:
                    return "en";
                case 4:
                    return "de";
                case 5:
                    if (IndexID2 == 1)
                        return "fra";
                    else
                        return "fr";
                case 6:
                    return "ru";
                case 7:
                    if (IndexID2 == 1)
                        return "spa";
                    else
                        return "es";
                case 8:
                    if (IndexID2 == 1)
                    {
                        return "yue";
                    }
                    else
                    {
                        MessageBox.Show("只有百度引擎支持粤语翻译!");
                        return "auto";
                    }
                default:
                    return "auto";
            }
        }


        /// <summary>
        ///     选择目标语言,除了auto其他和上面一样
        /// </summary>
        /// <param name="IndexID"></param>
        /// <returns></returns>
        private string TransTo(int IndexID, int IndexID2)
        {
            switch (IndexID)
            {
                case 0:
                    if (IndexID2 == 1)
                        return "zh";
                    else
                        return "zh-CN";
                case 1:
                    if (IndexID2 == 1)
                        return "jp";
                    else
                        return "ja";
                case 2:
                    return "en";
                case 3:
                    return "de";
                case 4:
                    if (IndexID2 == 1)
                        return "fra";
                    else
                        return "fr";
                case 5:
                    return "ru";
                case 6:
                    if (IndexID2 == 1)
                        return "spa";
                    else
                        return "es";
                case 7:
                    if (IndexID2 == 1)
                    {
                        return "yue";
                    }
                    else
                    {
                        MessageBox.Show("只有百度引擎支持粤语翻译!");
                        if (IndexID2 == 1)
                            return "zh";
                        return "zh-CN";
                        ;
                    }
                default:
                    if (IndexID2 == 1)
                        return "zh";
                    else
                        return "zh-CN";
                    ;
            }
        }


        /// <summary>
        ///     调用Timer1进行自动翻译 Timer1到期后启动新线程进行翻译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                checkBox1.Checked = false;
                timer1.Stop();
                return;
            }
            Thread t2;
            t2 = new Thread(Translate);
            t2.Start();
        }


        /// <summary>
        ///     checkedBox1勾选后激活Timer1进行自动翻译,取消勾选后关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                checkBox1.Checked = false;
            }
            else
            {
                if (checkBox1.Checked)
                {
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e) //按下同翻按钮新线程调用引擎进行翻译并显示结果
        {
            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            richTextBox2.Text = null;
            Thread t2;
            t2 = new Thread(TranslateAll);
            t2.Start();
        }

        private void 显示标题(string text) 
        {
            LogAppendDelegate la = LogAppend;
            richTextBox1.Invoke(la, Color.DeepPink, text);
        }

        private void 显示结果(string text)
        {
            LogAppendDelegate la = LogAppend;
            richTextBox1.Invoke(la, Color.LightSeaGreen, text);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        public void LogAppend(Color color, string text)
        {
            richTextBox2.SelectionColor = color;
            richTextBox2.AppendText(text);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (richTextBox2.Text == "") //如果文本框内没有文本则不能复制
            {
                MessageBox.Show("还未进行任何翻译", "注意");
                return;
            }
            if (state != 0) //检查翻译状态 同翻为0则弹出选择窗口 单引擎不为0则不弹出窗口直接复制
            {
                Clipboard.SetDataObject(C);
                metroLabel2.Text = "提示:复制成功";
            }
            else
            {
                var sd = new MyMessageBox(A, B);
                sd.ShowDialog(); //弹出选择窗口
                metroLabel2.Text = "提示:复制成功";
            }
        }
    }
}