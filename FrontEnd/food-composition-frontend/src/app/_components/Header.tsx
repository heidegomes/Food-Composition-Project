'use client';
import Link from "next/link";

export default function Header() {
  return (
    <header className="bg-green-600 text-white p-4 shadow-md">
      <div className="container mx-auto flex justify-between items-center">
        <Link href="/">
          <h1 className="text-2xl font-bold cursor-pointer">Food Composition App</h1>
        </Link>
        <div className="flex gap-4">
          <Link href="/aboutUs" className="text-white hover:text-gray-200">Sobre Nós</Link>
          <Link href="/contact" className="text-white hover:text-gray-200">Contato</Link>
        </div>
      </div>
    </header>
  );
};

