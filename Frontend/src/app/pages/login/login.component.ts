import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { APICommunicationService } from 'src/app/apicommunication.service';
import { StorageService } from 'src/app/storage.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  constructor(private localStorage: StorageService, private router: Router, private api: APICommunicationService) {}

  username:"";
  password:"";
  errorState: boolean = false;
  errorMsg: string = "";


  ngOnInit() {
  }
  ngOnDestroy() {
  }

  handleLogin() {
    if(this.username == "" || this.password == ""){
      this.errorState = true;
      this.errorMsg = "Please fill in all fields";
    }
    if(this.username.includes("@")){
      try {
        this.api.getAffiliatebyEmail(this.username).subscribe(
          (data: Object) => {
            if(data['0'] == undefined){
              this.errorState = true
              this.errorMsg = 'No employee found with that username'
              return
            }
            if (this.password !== data['0']['contrasena']) {
              this.errorState = true
              this.errorMsg = 'Email or password incorrect!'
              return
            }
            data['userType'] = 'affiliate';
            this.localStorage.saveData('user', JSON.stringify(data['0']));
            this.localStorage.saveData('userType', JSON.stringify(data['userType']));
            this.router.navigate(['/dashboard'])
            console.log("gucci affiliate")
            return
          }, (error => {
            if(error.status === 404){
              this.errorState = true
              this.errorMsg = 'Email or password incorrect!'
            }
            
          })

        )
    } catch (notFound) {
      this.api.getClientbyEmail(this.username).subscribe(
        (data: Object) => {
          if(data['0'] == undefined){
            this.errorState = true
            this.errorMsg = 'No employee found with that username'
            return
          }
          if (this.password !== data['0']['contrasena']) {
            this.errorState = true
            this.errorMsg = 'Email or password incorrect!'
            return
          }
          data['userType'] = 'client';
          this.localStorage.saveData('user', JSON.stringify(data['0']));
          this.localStorage.saveData('userType', JSON.stringify(data['userType']));
          this.router.navigate(['/dashboard'])
          
          console.log("gucci client")
          return
        }, (error => {
          if(error.status === 404){
            this.errorState = true
            this.errorMsg = 'Email or password incorrect!'
          }
          
        })

      )
    }
    } else {
      this.api.getEmployeebyUsername(this.username).subscribe(
        (data : Object) => {
          if(data['0'] == undefined){
            this.errorState = true
            this.errorMsg = 'No employee found with that username'
            return
          }
          if(this.password !== data['0']['contrasena']){
            this.errorState = true
            this.errorMsg = 'Email or password incorrect!'
            console.log(this.errorMsg)
            return
          }
          data['userType'] = 'employee';
          this.localStorage.saveData('user', JSON.stringify(data['0']));
          this.localStorage.saveData('userType', JSON.stringify(data['userType']));
          this.router.navigate(['/affiliates'])
          console.log("gucci employee")
  
          return
        }, (error => {
          if (error.status === 404) {
            this.errorState = true
            this.errorMsg = 'Email or password incorrect!'
          }
        })
      )
    }
    
    return
  }

}
