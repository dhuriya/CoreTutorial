import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-count',
  standalone: true,
  imports: [FormsModule],   // 👈 ngModel ke liye zaroori
  templateUrl: './student-count.html',
  styleUrls: ['./student-count.css']
})
export class StudentCount {
  @Input() all: number = 0;      // 👈 default value
  @Input() male: number = 0;     // 👈 default value
  @Input() female: number = 0;   // 👈 default value

  selectedRadioButtonValue: string = 'All';

  @Output() countRadioButtonSelectionChanged: EventEmitter<string> = new EventEmitter<string>();

  onRadioButtonSelectionChanges() {
    this.countRadioButtonSelectionChanged.emit(this.selectedRadioButtonValue);
  }
}