import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EBankingService } from 'src/app/services/e-banking.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public newForm: FormGroup;
  public selectedOrigin: number;
  public selectedDestination: number;
  public transference: any;
  public loading: boolean;
  public error: boolean;
  public errorMessage = '';
  public submitted: boolean;
  public allAccounts: any[];
  public availableAccounts: any[];

  constructor(
    private eBankingApi: EBankingService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.submitted = false;
    this.transference = {
      UserId: 0,
      Amount: 0,
      Description: '',
      OriginAccountId: 0,
      DestinationAccountId: 0,
      Date: new Date(),
      Id: 0
    };
    this.initForm();
    this.initData();
  }

  public initData() {
    this.eBankingApi.getUserAccounts().then((data: any[]) => {
      this.allAccounts = data;
      this.availableAccounts = data;
      this.selectedOrigin = data[0].id;
      this.selectedDestination = data[1].id;

    }, (err) => {
      console.log(err);
    });
  }

  private initForm() {
    this.newForm = this.formBuilder.group({
      Origin: [0, [Validators.required]],
      Destination: [0, [Validators.required]],
      Amount: [0, [Validators.required]],
      Description: [''],
    });
  }

  public submit() {
    this.submitted = true;
    this.error = false;
    if (!this.newForm.valid) {
      return;
    }
    if(this.newForm.get('Origin').value.Id === this.newForm.get('Destination').value.Id){
      this.error = true;
      this.errorMessage = "Las cuentas deben ser distintas";
      return;
    }
    this.sendTransference();
  }

  public changeValue(data) {
    // Remove element from destination accounts list
  }

  private sendTransference() {
    this.setTransferenceObject();
    this.eBankingApi.postTransference(this.transference).then((data: any[]) => {
      alert('La transacción fue realizada con éxito');
    }, (err) => {
      this.error = true;
      this.errorMessage = err.error.ErrorMessage;
    });
  }

  private setTransferenceObject() {
    this.transference.UserId = 1;
    this.transference.Amount = this.newForm.get('Amount').value;
    this.transference.Description = this.newForm.get('Description').value;
    this.transference.OriginAccountId = this.newForm.get('Origin').value.Id;
    this.transference.DestinationAccountId = this.newForm.get('Destination').value.Id;
    this.transference.Date = new Date();
    this.transference.Id = 0;
    }

}
