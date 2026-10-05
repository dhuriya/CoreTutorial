import { Directive, ElementRef, Input, Renderer2 } from '@angular/core';

@Directive({
    selector: '[appRequiredError]',
    standalone: true
})
export class RequiredErrorDirective {
    @Input() requiredField: boolean = false;
    @Input() showError: boolean = false;

    constructor(private el: ElementRef, private renderer: Renderer2) {}

    ngOnChanges(): void {
        this.applyRequiredErrorStyle();
    }

    private applyRequiredErrorStyle(): void {
        const element = this.el.nativeElement;

        this.renderer.removeStyle(element, 'border');
        this.renderer.removeStyle(element, 'box-shadow');

        if (this.requiredField && this.showError) {
            this.renderer.setStyle(element, 'border', '1px solid #dc3545');
            this.renderer.setStyle(element, 'box-shadow', '0 0 0 .2rem rgba(220, 53, 69, .15)');
        }
    }
}