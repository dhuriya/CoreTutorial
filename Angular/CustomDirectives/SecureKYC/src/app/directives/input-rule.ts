import { Directive, ElementRef, HostListener, Input } from "@angular/core";

@Directive({
    selector: '[appInputRule]',
    standalone: true
})
export class InputRuleDirective{
    @Input('appInputRule') rule : 'digits' | 'uppercase' = 'digits';
    constructor(private el: ElementRef){

    }
    @HostListener('input')
    onInput(){
        const input = this.el.nativeElement;
        let value = input.value;
        if(this.rule === 'digits'){
            value = value.replace(/\D+/g, '');
        }
        if(this.rule === 'uppercase'){
            value = value.toUpperCase();
        }
        if(input.value !== value){
            input.value = value;
            input.dispatchEvent(new Event('input'));
        }
    }
}