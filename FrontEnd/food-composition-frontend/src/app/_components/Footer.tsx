'use client';

export default function Footer() {
  return (
    <footer className="bg-green-600 text-white p-4 mt-8 shadow-inner">
      <div className="container mx-auto text-center">
        <p>&copy; {new Date().getFullYear()} Food Composition App. Todos os direitos reservados.</p>
      </div>
    </footer>
  );
};