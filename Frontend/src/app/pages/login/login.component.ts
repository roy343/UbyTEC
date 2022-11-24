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
    
    this.api.getEmployeebyUsername(this.username).subscribe(
      (data : Object) => {
        data['userType'] = 'employee';
        console.log(data);
        console.log(data['0']['contrasena']);
        //q: how do i get the password from the data object?
        //a: data['password']

        
        if(this.password !== data['0']['contrasena']){
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
          console.log(this.errorMsg)
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data))
        this.router.navigate(['/dashboard'])
        console.log("gucci employee")

        return
      }, (error => {
        if (error.status === 404) {
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
        }
      })
    )
    this.api.getAffiliatebyEmail(this.username).subscribe(
      (data: Object) => {
        data['userType'] = 'affiliate';

        if (this.password !== data['0']['contrasena']) {
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data))
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
    this.api.getClientbyEmail(this.username).subscribe(
      (data: Object) => {
        data['userType'] = 'client';

        if (this.password !== data['0']['contrasena']) {
          this.errorState = true
          this.errorMsg = 'Email or password incorrect!'
          return
        }
        
        this.localStorage.saveData('user', JSON.stringify(data))
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
    
    return
  }

}
