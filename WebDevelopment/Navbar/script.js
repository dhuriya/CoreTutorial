const hamgurder = document.getElementById("humbarger");
const navLinks = document.getElementById('navLinks');
hamgurder.addEventListener('click',() =>{
    hamgurder.classList.toggle('active');
    navLinks.classList.toggle('active');
});

//Close menu on link click(mobile)
document.querySelectorAll('.nav-links li a').forEach(link =>{
    link.addEventListener('click', ()=>{
        hamgurder.classList.remove('active');
        navLinks.classList.remove('active');
    })
})