ü<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Stock_Management_System.Main" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Main Page</title>
        <meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1">
        <!-- BOOTSTRAP START  -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
        <!-- BOOTSTRAP END  -->
    </head>
    <body>
        <form id="form1" runat="server">
 <!-- NAV START  -->
    <nav class="navbar navbar-expand-lg bg-body-tertiary ">
        <div class="container">
            <a class="navbar-brand" href="#">
                <img src="indir.png" alt="Logo" width="30" height="24" class="d-inline-block align-text-top">
                BOOTSTRAP
            </a>
            <div class="collapse navbar-collapse flex-row-reverse" id="navbarSupportedContent">
                <ul class="navbar-nav">
                    <li class="nav-item pe-3">
                        <a class="nav-link" href="Dashboard.aspx.aspx">DASHBOARD</a>
                    </li>
                    <li class="nav-item pe-3">
                        <a class="nav-link" href="Main.aspx">PRODUCT</a>
                    </li>
                    <li class="nav-item pe-3">
                        <a class="nav-link" href="Orders.aspx">ORDERS</a>
                    </li>
                    <li class="nav-item pe-3">
                        <a class="nav-link" href="Customer.aspx">CUSTOMER</a>
                    </li>
                    <li class="nav-item pe-3">
                        <a class="nav-link" href="Supplier.aspx">SUPPLIER</a>
                    </li>
                    <li class="nav-item pe-3">
                        <a class="nav-link" href="#">SETTİNGS <span style="margin-top:-10px"><svg
                                    xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                    class="bi bi-gear" viewBox="0 0 16 16" style="margin-top: -5px; color:#FFC107">
                                    <path
                                        d="M8 4.754a3.246 3.246 0 1 0 0 6.492 3.246 3.246 0 0 0 0-6.492zM5.754 8a2.246 2.246 0 1 1 4.492 0 2.246 2.246 0 0 1-4.492 0z" />
                                    <path
                                        d="M9.796 1.343c-.527-1.79-3.065-1.79-3.592 0l-.094.319a.873.873 0 0 1-1.255.52l-.292-.16c-1.64-.892-3.433.902-2.54 2.541l.159.292a.873.873 0 0 1-.52 1.255l-.319.094c-1.79.527-1.79 3.065 0 3.592l.319.094a.873.873 0 0 1 .52 1.255l-.16.292c-.892 1.64.901 3.434 2.541 2.54l.292-.159a.873.873 0 0 1 1.255.52l.094.319c.527 1.79 3.065 1.79 3.592 0l.094-.319a.873.873 0 0 1 1.255-.52l.292.16c1.64.893 3.434-.902 2.54-2.541l-.159-.292a.873.873 0 0 1 .52-1.255l.319-.094c1.79-.527 1.79-3.065 0-3.592l-.319-.094a.873.873 0 0 1-.52-1.255l.16-.292c.893-1.64-.902-3.433-2.541-2.54l-.292.159a.873.873 0 0 1-1.255-.52l-.094-.319zm-2.633.283c.246-.835 1.428-.835 1.674 0l.094.319a1.873 1.873 0 0 0 2.693 1.115l.291-.16c.764-.415 1.6.42 1.184 1.185l-.159.292a1.873 1.873 0 0 0 1.116 2.692l.318.094c.835.246.835 1.428 0 1.674l-.319.094a1.873 1.873 0 0 0-1.115 2.693l.16.291c.415.764-.42 1.6-1.185 1.184l-.291-.159a1.873 1.873 0 0 0-2.693 1.116l-.094.318c-.246.835-1.428.835-1.674 0l-.094-.319a1.873 1.873 0 0 0-2.692-1.115l-.292.16c-.764.415-1.6-.42-1.184-1.185l.159-.291A1.873 1.873 0 0 0 1.945 8.93l-.319-.094c-.835-.246-.835-1.428 0-1.674l.319-.094A1.873 1.873 0 0 0 3.06 4.377l-.16-.292c-.415-.764.42-1.6 1.185-1.184l.292.159a1.873 1.873 0 0 0 2.692-1.115l.094-.319z" />
                                </svg></span></a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- NAV END  -->
    <div class="container">
        <div class="row">
            <!-- FORM START  -->
            <div class="col-sm-4 mt-5">
                <div class="mt-3 mb-5">
                    <h3>ADD PRODUCT</h3>

                <div class="input-group pt-2">
                    <span class="input-group-text" id="inputGroup-sizing-lg">Product Name</span>
                    <asp:TextBox ID="Product_Name" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server" ></asp:TextBox>

                  </div>
                  <div class="input-group pt-3">
                    <span class="input-group-text" id="inputGroup-sizing-lg">Product Quantityt</span>
                    <asp:TextBox ID="Product_Quantity" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"></asp:TextBox>

                  </div>
                  <div class="input-group pt-3">
                    <span class="input-group-text" id="inputGroup-sizing-lg">Product Buy Price</span>
                    <asp:TextBox ID="Product_Buy_Price" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"></asp:TextBox>

                  </div>
                  <div class="input-group pt-3">
                    <span class="input-group-text" id="inputGroup-sizing-lg">Product Sell Price</span>
                    <asp:TextBox ID="Product_Buy_Sell" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"></asp:TextBox>

                  </div>
                  <div class="input-group pt-3">
                    <span class="input-group-text" id="inputGroup-sizing-lg">Product Category</span>
                    <asp:TextBox ID="Product_Category" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"></asp:TextBox>

                  </div>
                  <div class="input-group pt-3 d-flex justify-content-center">
                    <asp:Button ID="Save" class="btn btn-outline-warning btn-lg" runat="server" Text="Button" OnClick="Button1_Click" />

                  </div>
                  <div>
                    <asp:Label ID="Saved_Or_Not_label" runat="server" Text=""></asp:Label>
                  </div>

                </div>
            </div>
            <!-- FORM END  -->

            <!-- GridWiev  -->
            <div class="col-sm-8 mt-5" style="overflow-x:auto" >
                <div class="mt-3 mb-5 ps-5">
            <asp:GridView ID="Product_Grid"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="ID"
                OnRowCancelingEdit="Product_Grid_RowCancelingEdit"
                OnRowDeleting="Product_Grid_RowDeleting"
                OnRowEditing="Product_Grid_RowEditing"
                OnRowUpdating="Product_Grid_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="ID"  HeaderText="ID" ReadOnly="True"/>
                    <asp:BoundField DataField="PRODUCT_NAME"  HeaderText="Product Name"/>
                    <asp:BoundField DataField="PRODUCT_QUANTITY"  HeaderText="Product Quantity"/>
                    <asp:BoundField DataField="PRODUCT_BUY_PRICE"  HeaderText="Product Buy Price"/>
                    <asp:BoundField DataField="PRODUCT_SELL_PRICE"  HeaderText="Product Sell Price"/>
                    <asp:BoundField DataField="PRODUCT_CATEGORY"  HeaderText="Product Category"/>
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <!-- FOOTER START  -->
    <div class="container fixed-bottom">
        <footer class="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top">
            <p class="col-md-4 mb-0 text-muted">© 2022 Company, Incc>
                    <p class="col-md-4 mb-0 text-muted">© 2022 Company, Inc</p>
        
            <a href="/" class="col-md-4 d-flex align-items-center justify-content-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none">
              <svg class="bi me-2" width="40" height="32"><use xlink:href="#bootstrap"></use></svg>
            </a>
        
            <ul class="nav col-md-4 justify-content-end">
              <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">Home</a></li>
              <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">Features</a></li>
              <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">Pricing</a></li>
              <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">FAQs</a></li>
              <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">About</a></li>
            </ul>
          </footer>
    </div>
    <!-- FOOTER END  -->
    <!-- BOOTSTRAP START  -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"
        integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"
        integrity="sha384-mQ93GR66B00ZXjt0YO5KlohRA5SY2XofN4zfuZxLkoj1gXtW8ANNCe9d5Y3eG5eD"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN"
        crossorigin="anonymous"></script>
    <!-- BOOTSTRAP END  -->

    </form>
</body>
</html>
