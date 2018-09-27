// 20180927
// Solution1

 //set property
private void button1_Click(object sender, EventArgs e)
{
    this.myButton3.FillColor2 = Color.Yellow;
}

//set property
private void button2_Click(object sender, EventArgs e)
{
    this.myButton3.FillColor1 = Color.Red;
}

private void myButton1_Click(object sender, EventArgs e)
{
    AdventureWorksEntities dbContext = new AdventureWorksEntities();

    var q = from p in dbContext.ProductPhotoes
            select p;

    List<ProductPhoto> productList = q.ToList();

    this.dataGridView1.DataSource = productList;

    for (int i = 0; i < productList.Count -1; i++)
    {
        MyItemTemplate MIT = new MyItemTemplate();

        MIT.Desc = productList[i].ModifiedDate.ToLongDateString();
        MIT.ImageBytes = productList[i].LargePhoto;
        this.flowLayoutPanel1.Controls.Add(MIT);

        Application.DoEvents(); //同時跟者丟的意思
    }
}

private void myButton2_Click(object sender, EventArgs e)
{
    List<PhotoDataItem> productList = PhotoDataSource.Search(SearchTerm: "Microsoft", results: 100);

    this.dataGridView1.DataSource = productList;

    for (int i = 0; i < productList.Count - 1; i++)
    {
        MyItemTemplate MIT = new MyItemTemplate();

        MIT.Desc = productList[i].Title;
        MIT.ImagePath = productList[i].ImagePath;
        this.flowLayoutPanel1.Controls.Add(MIT);

        Application.DoEvents();  //加了這行比較屌

    }
 }



