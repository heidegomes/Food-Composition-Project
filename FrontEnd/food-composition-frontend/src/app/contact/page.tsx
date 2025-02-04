'use client';

export default function Contact() {
  return (
    <div className="flex justify-center items-center min-h-screen">
      <div className="bg-white border rounded-lg shadow-lg p-6 max-w-3xl w-full min-h-full">
        <h1 className="text-4xl font-bold text-center text-green-900 mb-6">Contato</h1>
        <p className="text-lg text-gray-700 mb-4">Email: contato@exemplo.com</p>
        <p className="text-lg text-gray-700">Telefone: (11) 1234-5678</p>
      </div>
    </div>
  );
}