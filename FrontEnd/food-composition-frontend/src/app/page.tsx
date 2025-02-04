'use client';
import { useEffect, useState } from "react";
import FoodCard from "@/app/_components/FoodCard";
import { FoodData } from "@/app/types";

export default function HomePage() {
  const [foodData, setFoodData] = useState<FoodData[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [page, setPage] = useState<number>(1); // Página atual
  const [pageSize] = useState<number>(10);     // Itens por página
  const [totalPages, setTotalPages] = useState<number>(1); // Total de páginas

  // Função para buscar dados com paginação
  const fetchData = async () => {
    try {
      const query = `page=${page}&size=${pageSize}${searchTerm ? `&search=${encodeURIComponent(searchTerm)}` : ''}`;
      const response = await fetch(`http://localhost:5057/api/food?${query}`);
      
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();

      // Captura os cabeçalhos de paginação
      const totalPagesHeader = response.headers.get("X-Total-Pages");
      setTotalPages(data.totalPages || Number(totalPagesHeader) || 1);

      setFoodData(data.items);
    } catch (error) {
      console.error("Erro ao buscar os dados:", error);
    }
  };

  // Carrega os dados sempre que a página muda
  useEffect(() => {
    fetchData();
  }, [page, searchTerm]);

  // Filtra os alimentos pelo termo de pesquisa
  const filteredFoods = foodData.filter(food =>
    food.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  // Função para mudar a página
  const handlePageChange = (newPage: number) => {
    if (newPage > 0 && newPage <= totalPages) {
      setPage(newPage);
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-4xl text-green-200 font-bold text-center mt-8">Composição Química</h1>
      <h2 className="text-2xl text-green-200 placeholder:font-bold text-center mb-8">(Informação Estatística)</h2>

      <input
        type="text"
        placeholder="Pesquisar alimentos..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        className="w-full p-2 mb-4 border rounded-lg bg-green-100 placeholder-green-900/50"
      />

      <div className="flex flex-col gap-6">
        {filteredFoods.map((food) => (
          <FoodCard key={food.code} food={food} />
        ))}
      </div>

      {/* Paginação */}
      <div className="flex justify-center mt-8 space-x-4">
        <button
          onClick={() => handlePageChange(page - 1)}
          disabled={page === 1}
          className="px-4 py-2 bg-green-500 text-white rounded-lg disabled:opacity-50"
        >
          Anterior
        </button>

        <span className="text-green-200 text-lg font-bold">
          Página {page} de {totalPages}
        </span>

        <button
          onClick={() => handlePageChange(page + 1)}
          disabled={page === totalPages}
          className="px-4 py-2 bg-green-500 text-white rounded-lg disabled:opacity-50"
        >
          Próxima
        </button>
      </div>
    </div>
  );
};
