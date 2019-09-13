import { NgModule } from '@angular/core';
import { MatDatepickerModule,
  MatNativeDateModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher} from '@angular/material';
import {MatButtonModule} from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    NoopAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatCardModule
  ],
  exports: [
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    NoopAnimationsModule,
    MatCardModule
  ],
  providers: [ MatDatepickerModule, {provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher} ],
})

export class MaterialModule {}
