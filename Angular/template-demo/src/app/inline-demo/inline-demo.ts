import { Component } from '@angular/core';

@Component({
  imports: [],
  selector: 'app-inline-demo',
  styleUrl: './inline-demo.css',
  template: `<h2> Inline Template Component </h2>
  <p>This UI is written directly inside the component file.</p>`,
})
export class InlineDemo {}
