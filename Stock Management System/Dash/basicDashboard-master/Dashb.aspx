<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashb.aspx.cs" Inherits="Stock_Management_System.Dash.basicDashboard_master.images.Dashb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="title icon" href="images/title-img.png">
     <!-- Bootstrap CSS -->
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"
    integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <script defer src="https://use.fontawesome.com/releases/v5.0.13/js/all.js" integrity="sha384-xymdQtn1n3lH2wcu0qhcdaOpQwyoarkgLVxC/wZ5q7h9gHtxICrpcaSUfygqZGOe" crossorigin="anonymous"></script>
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
    <link rel="stylesheet" href="style.css">
    <title>Admin Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
    <!--main navbar -->
    <nav class="navbar navbar-expand-md navbar-light">
        <button class="navbar-toggler ml-auto mb-2 bg-light" type="button" data-toggle="collapse" data-target="#myNavbar">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="myNavbar">
          <div class="container-fluid">
            <div class="row">
                <!-- sidebar -->
                    <div class="col-xl-2 col-lg-3 col-md-4 sidebar fixed-top">
                      <a href="#" class="navbar-brand text-white d-block mx-auto text-center py-3 mb-4 bottom-border">NameOfCompany</a>
                      <ul class="navbar-nav flex-column mt-4">
                        <li class="nav-item"><a href="https://localhost:44343/Main.aspx" class="nav-link text-white p-3 mb-2 current"><i class="fas fa-home text-light fa-lg mr-3"></i>Product</a></li>
                        <li class="nav-item"><a href="https://localhost:44343/Orders.aspx" class="nav-link text-white p-3 mb-2 sidebar-link"><i class="fas fa-user text-light fa-lg mr-3"></i>Orders</a></li>
                        <li class="nav-item"><a href="https://localhost:44343/Customer.aspx" class="nav-link text-white p-3 mb-2 sidebar-link"><i class="fas fa-user text-light fa-lg mr-3"></i>Customer</a></li>
                        <li class="nav-item"><a href="https://localhost:44343/Supplier.aspx" class="nav-link text-white p-3 mb-2 sidebar-link"><i class="fas fa-user text-light fa-lg mr-3"></i>Supplier</a></li>
                      </ul>
                    </div>
                    <!-- end -->  
                      
                       <!-- top-nav -->
            <div class="col-xl-10 col-lg-9 col-md-8 ml-auto bg-dark fixed-top py-2 top-navbar">
                <div class="row align-items-center">
                  <div class="col-md-4">
                    <h4 class="text-light text-uppercase mb-0">Dashboard</h4>
                  </div>
                  <div class="col-md-5">
                    <form>
                      <div class="input-group">
                        <input type="text" class="form-control search-input" placeholder="Search...">
                        <button type="button" class="btn btn-white search-button"><i class="fas fa-search text-danger"></i></button>
                      </div>
                    </form>
              </div>
              <!-- end of top-nav -->
            </div>
        </div>
      </div>
    </nav>
    <!-- end of navbar -->
    
    <!-- modal -->
    <div class="modal fade" id="sign-out">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Want to leave?</h4>
              <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
              Press logout to leave
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-success" data-dismiss="modal">Stay Here</button>
              <button type="button" class="btn btn-danger" data-dismiss="modal">Logout</button>
            </div>
          </div>
        </div>
      </div>
      <!-- end of modal -->

      <!-- cards -->
    <section>
        <div class="container-fluid">
          <div class="row">
            <div class="col-xl-10 col-lg-9 col-md-8 ml-auto">
              <div class="row pt-md-5 mt-md-3 mb-5">
                <div class="col-xl-3 col-sm-6 p-2">
                    <!-- Sales Count -->
                  <div class="card card-common">
                    <div class="card-body">
                      <div class="d-flex justify-content-between">
                        <i class="fas fa-shopping-cart fa-3x text-warning"></i>
                        <div class="text-right text-secondary">
                          <h5>Number Of Sales</h5>
                            <asp:Label ID="Sales_Count" runat="server" Text="Label"></asp:Label>
                        </div>
                      </div>
                    </div>
                    <div class="card-footer text-secondary">
                      <i class="fas fa-sync mr-3"></i>
                        <asp:Button ID="Update_Sales" runat="server" Text="Update now" OnClick="Update_Sales_Click" />
                    </div>
                  </div>
                </div>
                <div class="col-xl-3 col-sm-6 p-2">
                    <!-- Gain -->
                  <div class="card card-common">
                    <div class="card-body">
                      <div class="d-flex justify-content-between">
                        <i class="fas fa-money-bill-alt fa-3x text-success"></i>
                        <div class="text-right text-secondary">
                          <h5>Gain</h5>
                            <asp:Label ID="Total_Gain" runat="server" Text="Label"></asp:Label>
                        </div>
                      </div>
                    </div>
                    <div class="card-footer text-secondary">
                      <i class="fas fa-sync mr-3"></i>
                        <asp:Button ID="Update_Gain" runat="server" Text="Update now" OnClick="Update_Gain_Click" />
                    </div>
                  </div>
                </div>
                <div class="col-xl-3 col-sm-6 p-2">
                    <!-- Supplier Count -->
                  <div class="card card-common">
                    <div class="card-body">
                      <div class="d-flex justify-content-between">
                        <i class="fas fa-users fa-3x text-info"></i>
                        <div class="text-right text-secondary">
                          <h5>Number Of Supplier</h5>
                            <asp:Label ID="Supplier_Count" runat="server" Text="Label"></asp:Label>
                        </div>
                      </div>
                    </div>
                    <div class="card-footer text-secondary">
                      <i class="fas fa-sync mr-3"></i>
                        <asp:Button ID="Update_Supplier" runat="server" Text="Update now" OnClick="Update_Supplier_Click" />
                    </div>
                  </div>
                </div>
                <div class="col-xl-3 col-sm-6 p-2">
                    <!-- Customer Count -->
                  <div class="card card-common">
                    <div class="card-body">
                      <div class="d-flex justify-content-between">
                        <i class="fas fa-users fa-3x text-info"></i>
                        <div class="text-right text-secondary">
                            <h5>Number Of Customer</h5>
                            <asp:Label ID="Customer_Count" runat="server" Text="Label"></asp:Label>
                        </div>
                      </div>
                    </div>
                    <div class="card-footer text-secondary">
                      <i class="fas fa-sync mr-3"></i>
                        <asp:Button ID="Update_Customer" runat="server" Text="Update now" OnClick="Update_Customer_Click" />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <!-- end of cards -->
        
      <!-- tables gridviews -->
      <section>
        <div class="container-fluid" >
          <div class="row mb-5">
            <div class="col-xl-10 col-lg-9 col-md-8 ml-auto">
              <div class="row align-items-center">
                <div class="col-xl-6 col-12 mb-4 mb-xl-0">
                  <h3 class="text-muted text-center mb-3">Product Table</h3>
                    <div style="overflow-x:auto; White-space:nowrap; overflow-y:auto; max-height:1000px">
                    <asp:GridView ID="Product_Grid"
                        runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="ID">
                        <Columns>
                            <asp:BoundField DataField="ID"  HeaderText="ID" ReadOnly="True"/>
                            <asp:BoundField DataField="PRODUCT_NAME"  HeaderText="Product Name"/>
                            <asp:BoundField DataField="PRODUCT_QUANTITY"  HeaderText="Product Quantity"/>
                            <asp:BoundField DataField="PRODUCT_BUY_PRICE"  HeaderText="Product Buy Price"/>
                            <asp:BoundField DataField="PRODUCT_SELL_PRICE"  HeaderText="Product Sell Price"/>
                            <asp:BoundField DataField="PRODUCT_CATEGORY"  HeaderText="Product Category"/>
                        </Columns>
                    </asp:GridView>
                    </div>
  
                </div>
                <div class="col-xl-6 col-12">
                  <h3 class="text-muted text-center mb-3">Orders Table</h3>
                  <!-- class="table table-dark table-hover text-center" -->
                    <div style="overflow-x:auto; overflow-y:auto; max-height:1000px; width:100%; White-space:nowrap">
                <asp:GridView ID="Orders_Grid"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="ORDER_NUMBER">
                <Columns>
                    <asp:BoundField DataField="ORDER_NUMBER"  HeaderText="Order Number" ReadOnly="True"/>
                    <asp:BoundField DataField="ORDER_CUSTOMER_NAME"  HeaderText="Customer Name"/>
                    <asp:BoundField DataField="ORDER_CUSTOMER_ADDRESS"  HeaderText="Cutomer Address"/>
                    <asp:BoundField DataField="ORDER_CUSTOMER_CONTACT"  HeaderText="Cutomer Contact Info"/>
                    <asp:BoundField DataField="ORDER_PRODUCT_NAME"  HeaderText="Product Name"/>
                    <asp:BoundField DataField="ORDER_PRODUCT_QUANTITY"  HeaderText="Product Quantity"/>
                    <asp:BoundField DataField="ORDER_PRODUCT_BUY_PRICE"  HeaderText="Product Buy Price"/>
                    <asp:BoundField DataField="ORDER_PRODUCT_SELL_PRICE"  HeaderText="Product Sell Price"/>
                    <asp:BoundField DataField="ORDER_PRODUCT_CATEGORY"  HeaderText="Product Category"/>
                    <asp:BoundField DataField="ORDER_PRODUCT_GAIN"  HeaderText="Product Total Gain"/>
                </Columns>
            </asp:GridView>
                    </div>


                   <!-- pagination -->

                  <!-- end of pagination -->
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
      <!-- end of tables -->
     
  
      <!-- footer -->
      <footer>
        <div class="container-fluid">
          <div class="row">
            <div class="col-xl-10 col-lg-9 col-md-8 ml-auto">
              <div class="row border-top pt-3">
                <div class="col-lg-6 text-center">
                  <ul class="list-inline">
                    <li class="list-inline-item mr-2">
                      <a href="#" class="text-dark">Skill & Safari</a>
                    </li>
                    <li class="list-inline-item mr-2">
                      <a href="#" class="text-dark">About</a>
                    </li>
                    <li class="list-inline-item mr-2">
                      <a href="#" class="text-dark">Support</a>
                    </li>
                    <li class="list-inline-item mr-2">
                      <a href="#" class="text-dark">Blog</a>
                    </li>
                  </ul>
                </div>
                <div class="col-lg-6 text-center">
                  <p>&copy; 2020 Copyright. Made With <i class="fas fa-heart text-danger"></i> by <span class="text-success">Skill & Safari</span></p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </footer>
      <!-- end of footer -->
     
       <!-- Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"
      integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous">
    </script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"
      integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous">
    </script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"
      integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous">
    </script>
      <script src="script.js"></script>
        </div>
    </form>
</body>
</html>
