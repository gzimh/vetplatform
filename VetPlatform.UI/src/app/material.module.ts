import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatButtonModule, MatToolbarModule, MatDatepickerModule, MatFormFieldModule, MatNativeDateModule, MatInputModule, MatIconModule, MatCardModule, MatProgressSpinnerModule, MatChipsModule, MatDialogModule, MatButtonToggleModule, MatSnackBar, MatSnackBarModule, MatOptionModule, MatSelectModule} from '@angular/material'

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatButtonModule,
        MatToolbarModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatNativeDateModule,
        MatInputModule,
        MatIconModule,
        MatCardModule,
        MatProgressSpinnerModule,
        MatChipsModule,
        MatDialogModule,
        MatButtonToggleModule,
        MatSnackBarModule,
        MatOptionModule,
        MatSelectModule
    ],
    exports: [
        MatButtonModule,
        MatToolbarModule,
        MatDatepickerModule,
        MatFormFieldModule,
        MatNativeDateModule,
        MatInputModule,
        MatIconModule,
        MatCardModule,
        MatProgressSpinnerModule,
        MatChipsModule,
        MatDialogModule,
        MatButtonToggleModule,
        MatSnackBarModule,
        MatOptionModule,
        MatSelectModule
    ],
    providers: [],
})
export class MaterialModule {}
