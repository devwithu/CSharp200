using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebBrowserProject01{
public partial class Form1 : Form{
public Form1(){
    InitializeComponent();
}
private void toolStripTextBox1_KeyPress(object sender,
    KeyPressEventArgs e){
    if ((int)Keys.Enter == e.KeyChar){
        this.webBrowser1.Navigate(this.toolStripTextBox1.Text);
    }
}
private void toolStripButton1_Click(object sender, EventArgs e){
    try{
        webBrowser1.GoHome();
        this.toolStripTextBox1.Text = webBrowser1.Url.ToString();
    }
    catch (Exception){}
}
private void webBrowser1_Navigated(object sender, 
    WebBrowserNavigatedEventArgs e){
   string s = webBrowser1.Url.ToString();
    this.toolStripTextBox1.Text=s;
    if(!this.toolStripComboBox1.Items.Contains(s)){
        this.toolStripComboBox1.Items.Add(s);
    }
}
private void toolStripButton2_Click(object sender, EventArgs e){
    webBrowser1.Refresh();
}
private void toolStripButton4_Click(object sender, EventArgs e){
    if(this.webBrowser1.CanGoForward){
        webBrowser1.GoForward();
        this.toolStripTextBox1.Text = webBrowser1.Url.ToString();
    }
}
private void toolStripButton3_Click(object sender, EventArgs e){
    webBrowser1.Stop();
}

private void toolStripButton5_Click(object sender, EventArgs e){
    if (this.webBrowser1.CanGoBack){
        webBrowser1.GoBack();
        this.toolStripTextBox1.Text = webBrowser1.Url.ToString();
    }
}
private void webBrowser1_Navigating(object sender, 
    WebBrowserNavigatingEventArgs e){
   this.toolStripButton3.Enabled = true;
}

private void Form1_Load(object sender, EventArgs e){
    toolStripButton3.Enabled = false;//stop
    toolStripButton5.Enabled = false;//goback
    toolStripButton4.Enabled = false;//goforward
    this.webBrowser1.CanGoBackChanged+=
        new EventHandler(webBrowser1_CanGoBackChanged);
    this.webBrowser1.CanGoForwardChanged+=
        new EventHandler(webBrowser1_CanGoForwardChanged);
}

private void webBrowser1_DocumentCompleted(object sender,
    WebBrowserDocumentCompletedEventArgs e){
    this.toolStripButton3.Enabled = false;
}
private void webBrowser1_CanGoBackChanged(object sender,
    EventArgs e){
    if (webBrowser1.CanGoBack == true){
        toolStripButton5.Enabled = true;
    }
    else{
        toolStripButton5.Enabled = false;
    }
}
private void webBrowser1_CanGoForwardChanged(
    object sender,EventArgs e){
    if (webBrowser1.CanGoForward == true){
        toolStripButton4.Enabled = true;
    }
    else{
        toolStripButton4.Enabled = false;
    }
}
private void webBrowser1_ProgressChanged(object sender, 
    WebBrowserProgressChangedEventArgs e) {
    long total = e.MaximumProgress;
    long current = e.CurrentProgress;
    this.toolStripProgressBar1.Value=
        (int)(100.0* current/total);
}
private void toolStripComboBox1_SelectedIndexChanged(
    object sender, EventArgs e){
    this.webBrowser1.Navigate(
        this.toolStripComboBox1.SelectedItem as string);
}
    }
}