//
CREATE DEFINER=`localhost`@`%` PROCEDURE `RegViewAll`()
BEGIN
	SELECT * FROM tb10_apolices;
END


//
CREATE DEFINER=`localhost`@`%` PROCEDURE `RegViewById`(
	_tb10_id BIGINT(20)
)
BEGIN
	SELECT * FROM tb10_apolices WHERE tb10_id = _tb10_id;
END


//
CREATE DEFINER=`localhost`@`%` PROCEDURE `RegInsertOrUpdate`(
	_tb10_id BIGINT(20),
	_tb10_nr VARCHAR(60),
	_tb10_cpfcnpj VARCHAR(14),
	_tb10_placa VARCHAR(7),
	_tb10_valor_premio FLOAT(18,2)
)
BEGIN
	IF _tb10_id=0 THEN 
		INSERT INTO `tb10_apolices` (`tb10_nr`, `tb10_cpfcnpj`, `tb10_placa`, `tb10_valor_premio`) 
        VALUES (_tb10_nr, _tb10_cpfcnpj, _tb10_placa, _tb10_valor_premio);
	ELSE
		UPDATE `tb10_apolices` 
        SET 
        `tb10_nr` = _tb10_nr, 
        `tb10_cpfcnpj` = _tb10_cpfcnpj, 
        `tb10_placa` = _tb10_placa, 
        `tb10_valor_premio` = _tb10_valor_premio 
        WHERE (`tb10_id` = _tb10_id) LIMIT 1;
	END IF;
END


//
CREATE DEFINER=`localhost`@`%` PROCEDURE `RegDeleteById`(	_tb10_id BIGINT(20)
)
BEGIN
	DELETE FROM tb10_apolices WHERE tb10_id = _tb10_id LIMIT 1;
END





