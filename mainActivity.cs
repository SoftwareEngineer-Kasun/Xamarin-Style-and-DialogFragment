private Button signUp; 
private Button submitNewUser; 
private EditText txtUsername; 
private EditText txtEmail; 
private EditText txtPassword; 

protected override void OnCreate(Bundle bundle) { 

   base.OnCreate(bundle);  
   SetContentView(Resource.Layout.Main);
// load components   
   signUp = FindViewById<Button>(Resource.Id.btnSignUp); 
   submitNewUser = FindViewById<Button>(Resource.Id.btnSave); 
   txtUsername = FindViewById<EditText>(Resource.Id.txtUsername); 
   txtEmail = FindViewById<EditText>(Resource.Id.txtEmail); 
   txtPassword = FindViewById<EditText>(Resource.Id.txtPassword); 
            
   signUp.Click += (object sender, EventArgs args) => { 
   // here open the dialog fragment on ask
      FragmentTransaction transFrag = FragmentManager.BeginTransaction(); 
      SignUpDialog diagSignUp = new SignUpDialog(); 
      diagSignUp.Show(transFrag, "Fragment Dialog");
      
   // this being subsecribed to the event handler to run when an event complete   
      diagSignUp.onSignUpComplete += diagSignUp_onSignUpComplete; 
      
   }; 
}  
void diagSignUp_onSignUpComplete(object sender, OnSignUpEvent e) { 

// here open a separate view 
   StartActivity(typeof(Activity2)); 
}             
