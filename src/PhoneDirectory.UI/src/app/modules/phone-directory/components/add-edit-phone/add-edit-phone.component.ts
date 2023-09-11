import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { PhoneDirectoryService } from '../../services/phone-directory.service';
import { Phone, UpdatePhone } from '../../models';

@Component({
    selector: 'app-add-edit-phone',
    templateUrl: './add-edit-phone.component.html',
    styleUrls: ['./add-edit-phone.component.scss']
})
export class AddEditPhoneComponent implements OnInit {

    name = new FormControl('', [Validators.required]);
    phone = new FormControl('', [Validators.required]);
  
    constructor(
        private phoneDirectoryService: PhoneDirectoryService,
        public dialogRef: MatDialogRef<AddEditPhoneComponent>,
        @Inject(MAT_DIALOG_DATA) public data?: Phone
    ) {}
  
    get isUpdate(): boolean {
        return !!this.data;
    }
    
    ngOnInit(): void {
        if (this.data) {
            this.name.setValue(this.data.name);
            this.phone.setValue(this.data.number);
        }
    }

    submit(): void {
        if (!this.name.valid || !this.phone.valid) {
            return;
        }

        const model: UpdatePhone = {
            name: this.name.value!,
            number: this.phone.value!
        };

        if (this.isUpdate) {
            const id = this.data?.id as number;
            this.phoneDirectoryService.updatePhone(model, id).subscribe(result => this.close(result));
        } else {
            this.phoneDirectoryService.addPhone(model).subscribe(result => this.close(result));
        }
    }
  
    close(phone?: Phone): void {
        this.dialogRef.close(phone);
    }
}
