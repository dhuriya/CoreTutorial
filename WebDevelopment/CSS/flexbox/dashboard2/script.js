const hamburger = document.getElementById('hamburger');
const navLinks = document.querySelectorAll(".nav-links a");
hamburger.addEventListener("click", () => {
    const isOpen = document.body.classList.toggle("nav-open");
    hamburger.setAttribute("aria-expanded", String(isOpen));
});
navLinks.forEach((links) => {
    links.addEventListener("click", () =>{
        navLinks.forEach((l) => l.classList.remove("active"));
        links.classList.add("active");
        document.body.classList.remove("nav-open");
        hamburger.setAttribute("aria-expanded", "false");
    });
});
document.addEventListener("keydown", (e) => {
    if(e.key == "Escape"){
        document.body.classList.remove("nav-open");
        hamburger.setAttribute("aria-expanded", "false");
    }
})