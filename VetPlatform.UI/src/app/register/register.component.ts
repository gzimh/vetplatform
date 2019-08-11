import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from '../services/register.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  providers: [RegisterService]
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder,
     private registerService: RegisterService,
     private snackbar: MatSnackBar) { }

  ngOnInit() {
    this.form = this.fb.group({
      name: [null, []],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required]]
    });
  }

  save() {
    let formValue = this.form.value;

    this.registerService.save(formValue).subscribe(result => {
      if(result){
        this.snackbar.open('Account created.', 'OK', {
          duration: 3000
        });
      }
    },error => {
      console.log(error);
      this.snackbar.open('Something went wrong while completing the operation.', 'OK', {
        duration: 3000
      });
    });
  }

}
