import { Component } from '@angular/core';

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-dialog-content-component',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './dialog-content.component.html',
})
export class DialogContentExampleDialog {}
