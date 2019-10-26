// inherit from EventArgs to use its event properties

public class OnSignUpEvent:EventArgs { 
// save parameters
   private string myUserName; 
   private string myEmail; 
   private string myPassword; 
   
// here use the properties

   public string UserName { 
      get { 
         return myUserName; 
      } 
      set{ 
         myUserName = value;
      } 
   } 
      
   public string Email { 
      get { 
         return myEmail; 
      } 
      set { 
         myEmail = value; 
      } 
   } 
      
   public string Password { 
      get { 
         return myPassword; 
      } 
      set { 
         myPassword = value; 
      } 
   }  
   
   // this get called to store procidier
   
   public OnSignUpEvent(string username, string 
      email, string password):base() { 
      UserName = username; 
      Email = email; 
      Password = password; 
   } 
     
//main class inherit from DialogFragment to use its properties

   class SignUpDialog:DialogFragment { 
   
      private EditText txtUsername; 
      private EditText txtEmail; 
      private EditText txtPassword; 
      private Button btnSaveSignUp; 
      
      // here load the method OnSignUpEvent to eventhadler will get activated when get data provided
      
      public event EventHandler<OnSignUpEvent> onSignUpComplete; 
     
 // create the view    
      public override View OnCreateView(LayoutInflater inflater, 
         ViewGroup container, Bundle savedInstanceState) { 
         base.OnCreateView(inflater, container, savedInstanceState);  
 // here make the dialog box on load
         var view = inflater.Inflate(Resource.Layout.registerDialog, container, false); 
 // load the components
         txtUsername = view.FindViewById<EditText>(Resource.Id.txtUsername); 
         txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail); 
         txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
         btnSaveSignUp = view.FindViewById<Button>(Resource.Id.btnSave);
  // button event handler       
         btnSaveSignUp.Click += btnSaveSignUp_Click;  // run the  btnSaveSignUp_Click method
         return view; 
      }  
      
      void btnSaveSignUp_Click(object sender, EventArgs e) { 
      
      // here pass the data to event handler so it saves the data 
         onSignUpComplete.Invoke(this, new OnSignUpEvent(txtUsername.Text,txtEmail.Text, txtPassword.Text));
         
  // close the main class ( with the view )          
         this.Dismiss(); 
         
      } 
   }
}   
